using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YenCash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Quiz : ContentPage
    {
        public int changeDimension, defaultdimension;
        public string SelectedOption="";
        QuizTopic quizTopic;
        public int questioNumber, correctAnswers = 0;
        public QuizObject quizObject;

        public Quiz(QuizTopic selectedTopic)
        {
            quizObject = new QuizObject();
            quizTopic = selectedTopic;
            InitializeComponent();
            GetPageData();
            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;

            var chcoiceIconMetrices = width * 8;

            defaultdimension = width * 5;
            changeDimension = width * 10;
            
            imageChoice1.HeightRequest = chcoiceIconMetrices;
            imageChoice1.WidthRequest = chcoiceIconMetrices;

            imageChoice2.HeightRequest = chcoiceIconMetrices;
            imageChoice2.WidthRequest = chcoiceIconMetrices;

            imageChoice3.HeightRequest = chcoiceIconMetrices;
            imageChoice3.WidthRequest = chcoiceIconMetrices;

            imageChoice4.HeightRequest = chcoiceIconMetrices;
            imageChoice4.WidthRequest = chcoiceIconMetrices;
        }

        private async void NavigationTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PopModalAsync(false);
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        #region for choice clicked events
        private async void Choice1Tapped(object sender, EventArgs e)
        {
            try
            {
                await SetDefaultChoice();
                imageChoice1.Source = ImageSource.FromFile("RadioOn.png");
                //imageChoice1.HeightRequest = changeDimension;
                //imageChoice1.WidthRequest = changeDimension;
                SelectedOption = labelChoice1.Text;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void Choice2Tapped(object sender, EventArgs e)
        {
            try
            {
                await SetDefaultChoice();
                imageChoice2.Source = ImageSource.FromFile("RadioOn.png");
                //imageChoice2.HeightRequest = changeDimension;
                //imageChoice2.WidthRequest = changeDimension;
                SelectedOption = labelChoice2.Text;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void Choice3Tapped(object sender, EventArgs e)
        {
            try
            {
                await SetDefaultChoice();
                imageChoice3.Source = ImageSource.FromFile("RadioOn.png");
                //imageChoice3.HeightRequest = changeDimension;
                //imageChoice3.WidthRequest = changeDimension;
                SelectedOption = labelChoice3.Text;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void Choice4Tapped(object sender, EventArgs e)
        {
            try
            {
                await SetDefaultChoice();
                imageChoice4.Source = ImageSource.FromFile("RadioOn.png");
                //imageChoice4.HeightRequest = changeDimension;
                //imageChoice4.WidthRequest = changeDimension;
                SelectedOption = labelChoice4.Text;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async Task<bool> SetDefaultChoice()
        {
            try
            {
                SelectedOption = "";
                imageChoice1.Source = ImageSource.FromFile("RadioOff.png");
                imageChoice2.Source = ImageSource.FromFile("RadioOff.png");
                imageChoice3.Source = ImageSource.FromFile("RadioOff.png");
                imageChoice4.Source = ImageSource.FromFile("RadioOff.png");
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            return true;
        }
        #endregion

        private async Task<bool> GetPageData()
        {
            //stackLoader.IsVisible = true;
            try
            {
                var responseData = await GetQuestions();
                var questionsData = Newtonsoft.Json.JsonConvert.DeserializeObject<QuizObject>(responseData);
                quizObject = questionsData;

                labelQuestion.Text = questionsData.questions_set[0].question;
                labelChoice1.Text = questionsData.questions_set[0].option1;
                labelChoice2.Text = questionsData.questions_set[0].option2;
                labelChoice3.Text = questionsData.questions_set[0].option3;
                labelChoice4.Text = questionsData.questions_set[0].option4;

                questioNumber = 0;

                //labelQuestion.Text = "Which is the name of the robot that was given the saudi arabic Nationality ?";
                //labelChoice1.Text = "ELESA";
                //labelChoice2.Text = "Sofia";
                //labelChoice3.Text = "Jane";
                //labelChoice4.Text = "ChatBo";
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
            return true;
        }

        private async Task<string> GetQuestions()
        {
            string questions = "";
            //stackLoader.IsVisible = true;
            try
            {
                questions = "{\"questions_set\":" +
                    "[" +
                    "{\"question\" : \"Which is the name of the robot that was given the saudi arabic Nationality ?\",\"option1\":\"ELESA\",\"option2\":\"Sofia\",\"option3\":\"Jane\",\"option4\":\"ChatBo\",\"answer\":\"Sofia\"}," +
                    "{\"question\" : \"Which of the following features of Indian temples resembles pylons of the Egyptian temples?\",\"option1\":\"Lat\",\"option2\":\"Vimana\",\"option3\":\"Gopura\",\"option4\":\"Shikara\",\"answer\":\"Gopura\"}," +
                    "{\"question\" : \"Which crop is sown on the largest area in India? \",\"option1\":\"Rice\",\"option2\":\"Wheat\",\"option3\":\"Sugarcane\",\"option4\":\"Maize\",\"answer\":\"Rice\"}," +
                    "{\"question\" : \"A persistent fall in the general price level of goods and services is known as __:\",\"option1\":\"Deflation\",\"option2\":\"Disinflation\",\"option3\":\"StagFlation\",\"option4\":\"Depression\",\"answer\":\"Deflation\"}," +
                    "{\"question\" : \"The currency notes are printed in __: \",\"option1\":\"New Delhi\",\"option2\":\"Nasik\",\"option3\":\"Nagpur\",\"option4\":\"Bombay\",\"answer\":\"Nasik\"}" +
                    "]}";
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
            return questions;
        }

        private async void SubmitButtonClicked(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                if(string.IsNullOrEmpty(SelectedOption))
                {
                    await DisplayAlert("Alert", "Cannot submit without selecting any option", "Ok");
                }
                else
                {
                    var shallSubmitOption = await DisplayAlert("Alert", "Shall we submit your answer", "Ok", "Cancel");
                    if(shallSubmitOption)
                    {
                        if(SelectedOption == quizObject.questions_set[questioNumber].answer)
                        {
                            correctAnswers++;
                        }

                        if (questioNumber < 4)
                        {
                            GetNextQuestion(questioNumber + 1);
                        }
                        else
                        {
                            await DisplayAlert("Report", "Your result: " + correctAnswers.ToString() + "/5", "Ok");
                            var replayChoice = await DisplayAlert("Alert", "Do you want to play again", "Ok", "Cancel");
                            if(replayChoice == true)
                            {
                                correctAnswers = 0;
                                questioNumber = 0;
                                await SetDefaultChoice();
                                await GetPageData();
                            }
                            else
                            {
                                App.Current.MainPage = new HomePage();
                            }
                        }
                        //if(SelectedOption == "Sofia")
                        //{
                        //    await DisplayAlert("Alert", "Congo you made the correct option, you can now move to the next question", "Ok");
                        //}
                        //else
                        //{
                        //    await DisplayAlert("Alert", "Sorry. Better luck next time", "Ok");
                        //}
                    }
                    else
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void GetNextQuestion(int v)
        {
            try
            {
                var responseData = await GetQuestions();
                var questionsData = Newtonsoft.Json.JsonConvert.DeserializeObject<QuizObject>(responseData);
                await SetDefaultChoice();
                labelQuestion.Text = questionsData.questions_set[v].question;
                labelChoice1.Text = questionsData.questions_set[v].option1;
                labelChoice2.Text = questionsData.questions_set[v].option2;
                labelChoice3.Text = questionsData.questions_set[v].option3;
                labelChoice4.Text = questionsData.questions_set[v].option4;

                questioNumber = v;

                //labelQuestion.Text = "Which is the name of the robot that was given the saudi arabic Nationality ?";
                //labelChoice1.Text = "ELESA";
                //labelChoice2.Text = "Sofia";
                //labelChoice3.Text = "Jane";
                //labelChoice4.Text = "ChatBo";
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }
    }

    public class QuestionsSet
    {
        public string question { get; set; }
        public string option1 { get; set; }
        public string option2 { get; set; }
        public string option3 { get; set; }
        public string option4 { get; set; }
        public string answer { get; set; }
    }

    public class QuizObject
    {
        public List<QuestionsSet> questions_set { get; set; }
    }
}