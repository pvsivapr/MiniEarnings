using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YenCash
{
    public partial class UserLogin : ContentPage
    {
        public UserLogin()
        {
            InitializeComponent();
            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            gridDataInput.HeightRequest = height * 30;//screenHeight * 30;

            btnRegister.WidthRequest = width * 30;

            //viewMainHolder.Content = AbsHolder;

            entryUserEmail.Focused += entryUserEmailFocused;
            entryUserEmail.Unfocused += entryUserEmailUnFocused;

            entryUserPassword.Focused += entryUserPasswordFocused;
            entryUserPassword.Unfocused += entryUserPasswordUnFocused;

        }


        private void entryUserEmailFocused(object sender, FocusEventArgs e)
        {
            try
            {
                
            }
            catch(Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private void entryUserEmailUnFocused(object sender, FocusEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private void entryUserPasswordFocused(object sender, FocusEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private void entryUserPasswordUnFocused(object sender, FocusEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var isValid = await IsFormValid();
                if(isValid)
                {
                    
                }
                else
                {
                    
                }
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                returnValue = false;
                PrintLog.PublishLog(ex);
            }
            return returnValue;
        }

        private async void RegisterButtonClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new UserRegistration());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }
    }
}
