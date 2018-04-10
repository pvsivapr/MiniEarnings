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

            //imageSocialSharing.HeightRequest = imageMetrices;
            //imageSocialSharing.WidthRequest = imageMetrices;

            //imageSudoku.HeightRequest = imageMetrices;
            //imageSudoku.WidthRequest = imageMetrices;

            //gridDataInput.HeightRequest = height * 75;
            
        }

        private async void MasterNavigationTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                var ParentPage = (MasterDetailPage)this.Parent;
                ParentPage.IsPresented = (ParentPage.IsPresented == false) ? true : false;
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void SettingsTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new UserSettings(), false);
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
                await Navigation.PushModalAsync(new UserLogin(), false);
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
                await Navigation.PushModalAsync(new Lottery(new string[] { "Push" }), false);
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
                await Navigation.PushModalAsync(new SelectQuizSubject(new string[] { "Push" }), false);
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
                await Navigation.PushModalAsync(new Survey(new string[] { "Push" }), false);
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
                /*
                Image img = new Image()
                {
                    Source = "http://superwall.us/wallpaper/proposing_love_machine_rose_horse_robo_lady-oCrC.jpg",//"http://www.wintellect.com/devcenter/wp-content/uploads/2013/10/Wintellect_logo.gif",
                    Aspect = Aspect.AspectFit
                };
                */
                //DependencyService.Get<IShareService>().Share(" ", "Hi Gopi. How are you?", img.Source);
                //await Navigation.PushModalAsync(new SocialMedia());
                await Navigation.PushModalAsync(new SharePage(), false);
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
                await Navigation.PushModalAsync(new Sudoku(), false);
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

    }
}
