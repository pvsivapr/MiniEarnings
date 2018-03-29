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
        public Quiz()
        {
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
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

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

                //imageChoice1.HeightRequest = defaultdimension;
                //imageChoice1.WidthRequest = defaultdimension;

                //imageChoice2.HeightRequest = defaultdimension;
                //imageChoice2.WidthRequest = defaultdimension;

                //imageChoice3.HeightRequest = defaultdimension;
                //imageChoice3.WidthRequest = defaultdimension;

                //imageChoice4.HeightRequest = defaultdimension;
                //imageChoice4.WidthRequest = defaultdimension;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            return true;
        }

        private async Task<bool> GetPageData()
        {
            //stackLoader.IsVisible = true;
            try
            {
                labelQuestion.Text = "Which is the name of the robot that was given the saudi arabic Nationality ?";
                labelChoice1.Text = "ELESA";
                labelChoice2.Text = "Sofia";
                labelChoice3.Text = "Jane";
                labelChoice4.Text = "ChatBo";
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
            return true;
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
                        if(SelectedOption == "Sofia")
                        {
                            await DisplayAlert("Alert", "Congo you made the correct option, you can now move to the next question", "Ok");
                        }
                        else
                        {
                            await DisplayAlert("Alert", "Sorry. Better luck next time", "Ok");
                        }
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
    }
}