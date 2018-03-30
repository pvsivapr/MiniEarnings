using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace YenCash
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;

            var imageMetrices = width * 38;

            imageLottery.HeightRequest = imageMetrices;
            imageLottery.WidthRequest = imageMetrices;

            imageQuiz.HeightRequest = imageMetrices;
            imageQuiz.WidthRequest = imageMetrices;

            imageSurvey.HeightRequest = imageMetrices;
            imageSurvey.WidthRequest = imageMetrices;

            imageSocialSharing.HeightRequest = imageMetrices;
            imageSocialSharing.WidthRequest = imageMetrices;

            imageSudoku.HeightRequest = imageMetrices;
            imageSudoku.WidthRequest = imageMetrices;

            //gridDataInput.HeightRequest = height * 75;
            
        }

        private async void SettingsTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new UserSettings());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void LogoutTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new UserLogin());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void LotteryTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new Lottery());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }
        

        private async void QuizTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new SelectQuizSubject());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void SurveyTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new Survey());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void SocialSharingTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new SocialMedia());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void SudokuTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new Sudoku());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

    }
}
