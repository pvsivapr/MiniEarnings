using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace YenCash
{
    public partial class UserSettings : ContentPage
    {
        public UserSettings()
        {
            InitializeComponent();


            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;

            var imageMetrices = width * 38;

            imageUserProfile.HeightRequest = imageMetrices;
            imageUserProfile.WidthRequest = imageMetrices;

            imagePointsEarned.HeightRequest = imageMetrices;
            imagePointsEarned.WidthRequest = imageMetrices;

            imageFAQ.HeightRequest = imageMetrices;
            imageFAQ.WidthRequest = imageMetrices;

            imageAboutUs.HeightRequest = imageMetrices;
            imageAboutUs.WidthRequest = imageMetrices;

            //imageSudoku.HeightRequest = imageMetrices;
            //imageSudoku.WidthRequest = imageMetrices;

            //gridDataInput.HeightRequest = height * 25;

        }

        private async void NavigationTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void LogoutTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new UserLogin());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void UserProfileTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new UserProfile());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void PointsEarnedTapped(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void FAQTapped(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void AboutUsTapped(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void QuizTapped(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

    }
}