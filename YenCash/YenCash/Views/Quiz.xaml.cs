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
        public int changeDimension, defaultdimension, totalQuestions;
        public string SelectedOption="";
        QuizTopic quizTopic;
        public int questioNumber, correctAnswers = 0, unAttemptedQuestions = 0;
        public QuizObject quizObject;
        public bool isInReviewMode;

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

                if (!string.IsNullOrEmpty(SelectedOption))
                {
                    quizObject.questions_set[questioNumber].UserAnswer = SelectedOption;
                }
                else
                {

                }
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
                if (!string.IsNullOrEmpty(SelectedOption))
                {
                    quizObject.questions_set[questioNumber].UserAnswer = SelectedOption;
                }
                else
                {

                }
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
                if (!string.IsNullOrEmpty(SelectedOption))
                {
                    quizObject.questions_set[questioNumber].UserAnswer = SelectedOption;
                }
                else
                {

                }
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
                if (!string.IsNullOrEmpty(SelectedOption))
                {
                    quizObject.questions_set[questioNumber].UserAnswer = SelectedOption;
                }
                else
                {

                }
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

                if (isInReviewMode)
                {
                    labelChoice1.TextColor = Color.White;
                    labelChoice2.TextColor = Color.White;
                    labelChoice3.TextColor = Color.White;
                    labelChoice4.TextColor = Color.White;
                }
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
                totalQuestions = quizObject.questions_set.Count();

                labelQuestion.Text = quizObject.questions_set[0].Question;
                labelChoice1.Text = quizObject.questions_set[0].Option1;
                labelChoice2.Text = quizObject.questions_set[0].Option2;
                labelChoice3.Text = quizObject.questions_set[0].Option3;
                labelChoice4.Text = quizObject.questions_set[0].Option4;

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
                    "{\"Question\" : \"Which is the name of the robot that was given the saudi arabic Nationality ?\",\"Option1\":\"ELESA\",\"Option2\":\"Sofia\",\"Option3\":\"Jane\",\"Option4\":\"ChatBo\",\"UserAnswer\":\"\",\"Answer\":\"Sofia\"}," +
                    "{\"Question\" : \"Which of the following features of Indian temples resembles pylons of the Egyptian temples?\",\"Option1\":\"Lat\",\"Option2\":\"Vimana\",\"Option3\":\"Gopura\",\"Option4\":\"Shikara\",\"UserAnswer\":\"\",\"Answer\":\"Gopura\"}," +
                    "{\"Question\" : \"Which crop is sown on the largest area in India? \",\"Option1\":\"Rice\",\"Option2\":\"Wheat\",\"Option3\":\"Sugarcane\",\"Option4\":\"Maize\",\"UserAnswer\":\"\",\"Answer\":\"Rice\"}," +
                    "{\"Question\" : \"A persistent fall in the general price level of goods and services is known as __:\",\"Option1\":\"Deflation\",\"Option2\":\"Disinflation\",\"Option3\":\"StagFlation\",\"Option4\":\"Depression\",\"UserAnswer\":\"\",\"Answer\":\"Deflation\"}," +
                    "{\"Question\" : \"The currency notes are printed in __: \",\"Option1\":\"New Delhi\",\"Option2\":\"Nasik\",\"Option3\":\"Nagpur\",\"Option4\":\"Bombay\",\"UserAnswer\":\"\",\"Answer\":\"Nasik\"}" +
                    "]}";
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
            return questions;
        }

        private async void PreviousButtonClicked(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                questioNumber--;
                GetQuestion(questioNumber);
                if(questioNumber <= 0)
                {
                    PreviousButton.IsVisible = false;
                }
                if(NextButton.IsVisible == false)
                {
                    NextButton.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void NextButtonClicked(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                questioNumber++;
                GetQuestion(questioNumber);
                if (questioNumber >= totalQuestions-1)
                {
                    NextButton.IsVisible = false;
                }
                if (PreviousButton.IsVisible == false)
                {
                    PreviousButton.IsVisible = true;
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void SubmitButtonClicked(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                //if(string.IsNullOrEmpty(SelectedOption))
                //{
                //    await DisplayAlert("Alert", "Cannot submit without selecting any option", "Ok");
                //}
                //else
                //{
                    var shallSubmitOption = await DisplayAlert("Alert", "Shall we submit your answers", "Ok", "Cancel");
                if (shallSubmitOption)
                {
                    unAttemptedQuestions = 0;
                    foreach(var item in quizObject.questions_set)
                    {
                        if(string.IsNullOrEmpty(item.UserAnswer))
                        {
                            unAttemptedQuestions++;
                        }
                        else
                        {

                            if (item.UserAnswer == item.Answer)
                            {
                                correctAnswers++;
                            }
                            else
                            {

                            }
                        }

                    }

                    var results = "Total Questions : " + totalQuestions + "\n" +
                        "Attempted Questions : " + (totalQuestions - unAttemptedQuestions).ToString() + "\n" +
                                                                                          "UnAttempted Questions : " + (unAttemptedQuestions).ToString() + "\n" +
                                                                                          "Correct Answers : " + (correctAnswers).ToString() + "\n" +
                                                                                          "Wrong Answers : " + ((totalQuestions - unAttemptedQuestions) - correctAnswers).ToString();
                    var shallReview = await DisplayAlert("Scores of this quiz is :", results, "Review", "Close");
                    if (shallReview)
                    {
                        isInReviewMode = true;
                        SubmitButton.IsVisible = false;
                        GetQuestion(0);
                    }
                    else
                    {

                    }

                    //if(SelectedOption == quizObject.questions_set[questioNumber].Answer)
                    //{
                    //    correctAnswers++;
                    //}
                    //if (questioNumber < 4)
                    //{
                    //    //GetQuestion(questioNumber + 1);
                    //}
                    //else
                    //{
                    //    await DisplayAlert("Report", "Your result: " + correctAnswers.ToString() + "/5", "Ok");
                    //    var replayChoice = await DisplayAlert("Alert", "Do you want to play again", "Ok", "Cancel");
                    //    if(replayChoice == true)
                    //    {
                    //        correctAnswers = 0;
                    //        questioNumber = 0;
                    //        await SetDefaultChoice();
                    //        await GetPageData();
                    //    }
                    //    else
                    //    {
                    //        App.Current.MainPage = new HomePage();
                    //    }
                    //}
                    ////if(SelectedOption == "Sofia")
                    ////{
                    ////    await DisplayAlert("Alert", "Congo you made the correct option, you can now move to the next question", "Ok");
                    ////}
                    ////else
                    ////{
                    ////    await DisplayAlert("Alert", "Sorry. Better luck next time", "Ok");
                    ////}
                }
                else
                {


                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void GetQuestion(int v)
        {
            try
            {
                //var responseData = await GetQuestions();
                //var questionsData = Newtonsoft.Json.JsonConvert.DeserializeObject<QuizObject>(responseData);
                await SetDefaultChoice();
                labelQuestion.Text = quizObject.questions_set[v].Question;
                labelChoice1.Text = quizObject.questions_set[v].Option1;
                labelChoice2.Text = quizObject.questions_set[v].Option2;
                labelChoice3.Text = quizObject.questions_set[v].Option3;
                labelChoice4.Text = quizObject.questions_set[v].Option4;


                if (isInReviewMode)
                {
                    if (!string.IsNullOrEmpty(quizObject.questions_set[v].UserAnswer))
                    {
                        SelectedOption = quizObject.questions_set[v].UserAnswer;
                        var correctAnswer = quizObject.questions_set[v].Answer;

                        if ((SelectedOption) == (labelChoice1.Text))
                        {
                            //imageChoice1.Source = ImageSource.FromFile("RadioOn.png");
                            if (SelectedOption == correctAnswer)
                            {
                                labelChoice1.TextColor = Color.Green;
                            }
                            else
                            {
                                labelChoice1.TextColor = Color.Red;
                                if (correctAnswer == labelChoice2.Text)
                                {
                                    labelChoice2.TextColor = Color.Green;
                                }
                                else if (correctAnswer == labelChoice3.Text)
                                {
                                    labelChoice3.TextColor = Color.Green;
                                }
                                else if (correctAnswer == labelChoice4.Text)
                                {
                                    labelChoice4.TextColor = Color.Green;
                                }
                                else
                                {

                                }
                            }

                        }
                        else if ((SelectedOption) == (labelChoice2.Text))
                        {
                            //imageChoice1.Source = ImageSource.FromFile("RadioOn.png");
                            if (SelectedOption == correctAnswer)
                            {
                                labelChoice2.TextColor = Color.Green;
                            }
                            else
                            {
                                labelChoice2.TextColor = Color.Red;
                                if (correctAnswer == labelChoice1.Text)
                                {
                                    labelChoice1.TextColor = Color.Green;
                                }
                                else if (correctAnswer == labelChoice3.Text)
                                {
                                    labelChoice3.TextColor = Color.Green;
                                }
                                else if (correctAnswer == labelChoice4.Text)
                                {
                                    labelChoice4.TextColor = Color.Green;
                                }
                                else
                                {

                                }
                            }
                        }
                        else if ((SelectedOption) == (labelChoice3.Text))
                        {
                            //imageChoice1.Source = ImageSource.FromFile("RadioOn.png");
                            if (SelectedOption == correctAnswer)
                            {
                                labelChoice3.TextColor = Color.Green;
                            }
                            else
                            {
                                labelChoice3.TextColor = Color.Red;
                                if (correctAnswer == labelChoice2.Text)
                                {
                                    labelChoice2.TextColor = Color.Green;
                                }
                                else if (correctAnswer == labelChoice1.Text)
                                {
                                    labelChoice1.TextColor = Color.Green;
                                }
                                else if (correctAnswer == labelChoice4.Text)
                                {
                                    labelChoice4.TextColor = Color.Green;
                                }
                                else
                                {

                                }
                            }
                        }
                        else if ((SelectedOption) == (labelChoice4.Text))
                        {
                            //imageChoice1.Source = ImageSource.FromFile("RadioOn.png");
                            if (SelectedOption == correctAnswer)
                            {
                                labelChoice4.TextColor = Color.Green;
                            }
                            else
                            {
                                labelChoice4.TextColor = Color.Red;
                                if (correctAnswer == labelChoice2.Text)
                                {
                                    labelChoice2.TextColor = Color.Green;
                                }
                                else if (correctAnswer == labelChoice1.Text)
                                {
                                    labelChoice1.TextColor = Color.Green;
                                }
                                else if (correctAnswer == labelChoice3.Text)
                                {
                                    labelChoice3.TextColor = Color.Green;
                                }
                                else
                                {

                                }
                            }
                        }
                        else
                        {
                            if (correctAnswer == labelChoice1.Text)
                            {
                                labelChoice1.TextColor = Color.Green;
                            }
                            else if (correctAnswer == labelChoice2.Text)
                            {
                                labelChoice2.TextColor = Color.Green;
                            }
                            else if (correctAnswer == labelChoice3.Text)
                            {
                                labelChoice3.TextColor = Color.Green;
                            }
                            else if (correctAnswer == labelChoice4.Text)
                            {
                                labelChoice4.TextColor = Color.Green;
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        var correctAnswer = quizObject.questions_set[v].Answer;

                        if ((correctAnswer) == (labelChoice1.Text))
                        {
                            Choice1Tapped(null, null);
                        }
                        else if ((correctAnswer) == (labelChoice2.Text))
                        {
                            Choice2Tapped(null, null);
                        }
                        else if ((correctAnswer) == (labelChoice3.Text))
                        {
                            Choice3Tapped(null, null);
                        }
                        else if ((correctAnswer) == (labelChoice4.Text))
                        {
                            Choice4Tapped(null, null);
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(quizObject.questions_set[v].UserAnswer))
                    {
                        SelectedOption = quizObject.questions_set[v].UserAnswer;

                        if ((SelectedOption) == (labelChoice1.Text))
                        {
                            Choice1Tapped(null, null);
                        }
                        else if ((SelectedOption) == (labelChoice2.Text))
                        {
                            Choice2Tapped(null, null);
                        }
                        else if ((SelectedOption) == (labelChoice3.Text))
                        {
                            Choice3Tapped(null, null);
                        }
                        else if ((SelectedOption) == (labelChoice4.Text))
                        {
                            Choice4Tapped(null, null);
                        }
                        else
                        {

                        }
                    }
                }

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
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string UserAnswer { get; set; }
        public string Answer { get; set; }
    }

    public class QuizObject
    {
        public List<QuestionsSet> questions_set { get; set; }
    }
}