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

            gridDataInput.HeightRequest = height * 75;
            
        }

        private void LotteryTapped(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private void QuizTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new Quiz());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

    }
}
