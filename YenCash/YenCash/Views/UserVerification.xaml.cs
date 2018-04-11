using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YenCash
{
    //[XamlCompilation(XamlCompilationOptions.Compile)] 
    public partial class UserVerification : ContentPage
    {
        public UserVerification()
        {
            InitializeComponent();

            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;
        }

        private async void NavigationTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync(false);
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void VerifyButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var isValid = await IsFormValid();
                if (isValid)
                {
                    //App.Current.MainPage = new HomePage();
                    App.Current.MainPage = new MasterPage("HomePage");
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

        private async Task<bool> IsFormValid()
        {
            bool returnValue;
            try
            {
                returnValue = true;
            }
            catch (Exception ex)
            {
                returnValue = false;
                PrintLog.PublishLog(ex);
            }
            return returnValue;
        }
    }
}