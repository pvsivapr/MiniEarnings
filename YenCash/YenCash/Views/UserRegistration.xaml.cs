using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YenCash
{
    public partial class UserRegistration : ContentPage
    {
        public UserRegistration()
        {
            InitializeComponent();
            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            gridDataInput.HeightRequest = height * 65;//screenHeight * 30;

            btnLogin.WidthRequest = width * 30;

            stackFooterButton.HeightRequest = height * 9;

            //viewMainHolder.Content = AbsHolder;
        }


        private async void RegisterButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var isValid = await IsFormValid();
                if (isValid)
                {
                    Navigation.PushModalAsync(new UserVerification());
                    //Navigation.PushModalAsync(new HomePage());
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

        private async void LoginButtonClicked(object sender, EventArgs e)
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
    }
}
