using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YenCash
{
    public partial class MasterMenuPage : ContentPage
    {
        public MasterMenuPage()
        {
            InitializeComponent();

            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;

            var imageMetrices = width * 10;

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

            imageoffers.HeightRequest = imageMetrices;
            imageoffers.WidthRequest = imageMetrices;

            imageWriteFeedback.HeightRequest = imageMetrices;
            imageWriteFeedback.WidthRequest = imageMetrices;

            imageFAQs.HeightRequest = imageMetrices;
            imageFAQs.WidthRequest = imageMetrices;

            imageTermsConditions.HeightRequest = imageMetrices;
            imageTermsConditions.WidthRequest = imageMetrices;

            imageAboutUs.HeightRequest = imageMetrices;
            imageAboutUs.WidthRequest = imageMetrices;

            imageContactUs.HeightRequest = imageMetrices;
            imageContactUs.WidthRequest = imageMetrices;

            imageRateOurApp.HeightRequest = imageMetrices;
            imageRateOurApp.WidthRequest = imageMetrices;

        }

        private async void LotteryTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                App.Current.MainPage = new MasterPage("LotteryPage");
                ClosePage();
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
                App.Current.MainPage = new MasterPage("QuizPage");
                ClosePage();
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
                App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
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
                //App.Current.MainPage = new SocialMedia());
                //App.Current.MainPage = new SharePage();
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
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
                //App.Current.MainPage = new Sudoku();
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void offersTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void WriteFeedbackTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void FAQsTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void TermsConditionsTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void AboutUsTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void ContactUsTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async void RateOurAppTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                //App.Current.MainPage = new MasterPage("SurveyPage");
                ClosePage();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }


        public async Task<bool> ClosePage()
        {
            try
            {
                var parentDetailView = (MasterDetailPage)this.Parent;
                parentDetailView.IsPresented = false;
            }
            catch(Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            return true;
        }

    }
}
