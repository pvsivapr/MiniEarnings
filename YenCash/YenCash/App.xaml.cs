using Xamarin.Forms;

namespace YenCash
{
    public partial class App : Application
    {
        public static int screenHeight, screenWidth;
        public App()
        {
            InitializeComponent();

            //int HeaderTextSize = screenWidth * 6;

            //Resources = new ResourceDictionary();
            //Resources.Add("HeaderTextSize", HeaderTextSize);


            //MainPage = new HomePage();
            //MainPage = new TestView();
            MainPage = new UserLogin();
            //MainPage = new UserSettings();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
