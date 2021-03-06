﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace YenCash
{
    public partial class UserSettings : ContentPage
    {
        string pageType;
        public UserSettings(string[] pageSettings)
        {
            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;


            InitializeComponent();
            pageType = pageSettings[0];
            if (pageType == "MasterPage")
            {
                imageMainNavigation.Source = ImageSource.FromFile("MenuHamBurger.png");
            }
            else
            {
                imageMainNavigation.Source = ImageSource.FromFile("LeftArrowWhite.png");
            }



            pageTitle.FontSize = width * 6;

            var imageMetrices = width * 35;

            imageUserProfile.HeightRequest = imageMetrices;
            imageUserProfile.WidthRequest = imageMetrices;

            imageChangePassword.HeightRequest = imageMetrices;
            imageChangePassword.WidthRequest = imageMetrices;

            imagePointsEarned.HeightRequest = imageMetrices;
            imagePointsEarned.WidthRequest = imageMetrices;

            imageKYC.HeightRequest = imageMetrices;
            imageKYC.WidthRequest = imageMetrices;

            imagePayment.HeightRequest = imageMetrices;
            imagePayment.WidthRequest = imageMetrices;

            //imageFAQ.HeightRequest = imageMetrices;
            //imageFAQ.WidthRequest = imageMetrices;

            //imageAboutUs.HeightRequest = imageMetrices;
            //imageAboutUs.WidthRequest = imageMetrices;


            //imageSudoku.HeightRequest = imageMetrices;
            //imageSudoku.WidthRequest = imageMetrices;

            //gridDataInput.HeightRequest = height * 80;

        }

        private async void NavigationTapped(object sender, EventArgs e)
        {
            try
            {
                if (pageType == "MasterPage")
                {
                    var ParentPage = (MasterDetailPage)this.Parent;
                    ParentPage.IsPresented = (ParentPage.IsPresented == false) ? true : false;
                }
                else
                {
                    Navigation.PopModalAsync(false);
                }

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
                Navigation.PushModalAsync(new UserLogin(), false);
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
                await Navigation.PushModalAsync(new UserProfile(), false);
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void ChangePasswordTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new ChangePassword(), false);
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
                //await Navigation.PushModalAsync(new UserProfile());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void KYCTapped(object sender, EventArgs e)
        {
            try
            {
                //await Navigation.PushModalAsync(new UserProfile());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void PaymentTapped(object sender, EventArgs e)
        {
            try
            {
                //await Navigation.PushModalAsync(new UserProfile());
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
                //await Navigation.PushModalAsync(new UserProfile());
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
                //await Navigation.PushModalAsync(new UserProfile());
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
                //await Navigation.PushModalAsync(new UserProfile());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

    }
}