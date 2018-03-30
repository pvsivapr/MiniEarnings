using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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


            entryUserPassword.IsCustomPassword = true;
            entryUserPassword.IsPassword = true;

            gridDataInput.HeightRequest = height * 65;//screenHeight * 30;

            btnLogin.WidthRequest = width * 30;

            stackFooterButton.HeightRequest = height * 9;

            entryUserMobile.TextChanged += MobileNumberEdited;

            //viewMainHolder.Content = AbsHolder;
        }

        private void MobileNumberEdited(object sender, TextChangedEventArgs e)
        {
            try
            {
                var mobileNumber = e.NewTextValue;
                if(mobileNumber.Length > 10)
                {
                    entryUserMobile.Text = entryUserMobile.Text.Remove((entryUserMobile.Text.Length) - 1);
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private void PasswordEdited(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(entryUserPassword.Text)))
                {
                    imagePasswordAccess.Opacity = 1;
                    //imagePasswordAccess.IsVisible = true;
                    imagePasswordAccess.IsEnabled = true;
                }
                else
                {
                    imagePasswordAccess.Opacity = 0;
                    //imagePasswordAccess.IsVisible = false;
                    imagePasswordAccess.IsEnabled = false;
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
                if(entryUserPassword.IsPassword)
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

        private async void HaveOTPTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new UserVerification());
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
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
            bool returnValue = false;
            try
            {
                if (string.IsNullOrEmpty(entrytUserFirstName.Text))
                {
                    await DisplayAlertMessage("First Name cannot be empty");
                }
                else if(string.IsNullOrEmpty(entryUserLastName.Text))
                {
                    await DisplayAlertMessage("Last Name cannot be empty");
                }
                else if (string.IsNullOrEmpty(entryUserMobile.Text))
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
                else if (string.IsNullOrEmpty(entryUserEmail.Text))
                {
                    await DisplayAlertMessage("Email id is not valid, please enter a valid mobile number");
                }
                else if (!(Regex.IsMatch(entryUserEmail.Text, "^([1-9a-zA-Z.*]+)(@)([a-z|A-Z]+)(.)([a-z|A-Z]+)([.]{0,1})?([a-z|A-Z]+)$")))
                {
                    await DisplayAlertMessage("Invalid Email Id");
                }
                else
                {
                    returnValue = true;
                }
            }
            catch (Exception ex)
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
