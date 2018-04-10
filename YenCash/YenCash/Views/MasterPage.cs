using System;

using Xamarin.Forms;

namespace YenCash
{
    public class MasterPage : MasterDetailPage
    {
        public MasterPage(string pagename)
        {
            this.Icon = null;
            this.Title = "Menu";

            NavigationPage.SetHasNavigationBar(this, false);

            //InitializeComponent();


            Application.Current.Properties["ParentPage"] = this;

            string[] pageSettings;

            Master = new MasterMenuPage();
            if (pagename == "HomePage")
            {
                Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "LotteryPage")
            {
                pageSettings = new string[] { "Master" };
                Detail = new Lottery(pageSettings) { BackgroundColor = Color.White };
            }
            else if(pagename == "QuizPage")
            {
                Detail = new SelectQuizSubject(new string[] { "Master" }) { BackgroundColor = Color.White };
            }
            else if (pagename == "SurveyPage")
            {
                Detail = new Survey(new string[] { "Master" }) { BackgroundColor = Color.White };
            }
            else if (pagename == "SocialisePage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "SudokuPage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "OffersPage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "WriteFeedbackPage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "FAQsPage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "TermsConditionsPage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "AboutUsPage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "ContactUsPage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else if (pagename == "RateOurAppPage")
            {
                //Detail = new HomePage() { BackgroundColor = Color.White };
            }
            else
            {
                Detail = new HomePage() { BackgroundColor = Color.White, };
            }
            //Detail = new HomePageTest() { BackgroundColor = Color.White, };
        }
    }
}

