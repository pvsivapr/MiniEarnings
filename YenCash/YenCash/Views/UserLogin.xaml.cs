using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

            entryUserPassword.IsCustomPassword = true;
            entryUserPassword.IsPassword = true;

            gridDataInput.HeightRequest = height * 35;//screenHeight * 30;

            btnRegister.WidthRequest = width * 30;

            stackFooterButton.HeightRequest = height * 9;

            //viewMainHolder.Content = AbsHolder;

            //entryUserEmail.Focused += entryUserEmailFocused;
            //entryUserEmail.Unfocused += entryUserEmailUnFocused;

            //entryUserPassword.Focused += entryUserPasswordFocused;
            //entryUserPassword.Unfocused += entryUserPasswordUnFocused;

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



        private void MobileNumberEdited(object sender, TextChangedEventArgs e)
        {
            try
            {
                var mobileNumber = e.NewTextValue;
                if (mobileNumber.Length > 10)
                {
                    entryUserMobile.Text = entryUserMobile.Text.Remove((entryUserMobile.Text.Length) - 1);
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void PasswordVisibilityClicked(object sender, EventArgs e)
        {
            try
            {
                if (entryUserPassword.IsPassword)
                {
                    entryUserPassword.IsCustomPassword = false;
                    entryUserPassword.IsPassword = false;
                }
                else
                {
                    entryUserPassword.IsCustomPassword = true;
                    entryUserPassword.IsPassword = true;
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }


        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                var isValid = await IsFormValid();
                if(isValid)
                {
                    //Navigation.PushModalAsync(new UserProfile());
                    App.Current.MainPage = new HomePage();
                }
                else
                {
                    
                }
            }
            catch(Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }

        private async Task<bool> IsFormValid()
        {
            bool returnValue = false;
            try
            {
                if (string.IsNullOrEmpty(entryUserMobile.Text))
                {
                    await DisplayAlertMessage("Mobile Number cannot be empty");
                }
                else if (!(Regex.IsMatch(entryUserMobile.Text, "^[1-9][0-9]{9}$")))
                {
                    await DisplayAlertMessage("Mobile Number is not valid, please enter a valid mobile number");
                }
                else if (string.IsNullOrEmpty(entryUserPassword.Text))
                {
                    await DisplayAlertMessage("Password cannot be empty");
                }
                else
                {
                    returnValue = true;
                }
            }
            catch(Exception ex)
            {
                returnValue = false;
                PrintLog.PublishLog(ex);
            }
            return returnValue;
        }

        private async Task<bool> DisplayAlertMessage(string msg)
        {
            try
            {
                await DisplayAlert("Alert", msg, "Cancel");
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            return true;
        }

        private async void RegisterButtonClicked(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PushModalAsync(new UserRegistration());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }
    }
}
