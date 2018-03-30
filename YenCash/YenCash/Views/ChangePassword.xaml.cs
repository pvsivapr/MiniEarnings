using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace YenCash
{
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();

            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;

            entryOldPassword.IsCustomPassword = true;
            entryOldPassword.IsPassword = true;

            entryNewPassword.IsCustomPassword = true;
            entryNewPassword.IsPassword = true;

            gridDataInput.HeightRequest = height * 65;//screenHeight * 30;

            //viewMainHolder.Content = AbsHolder;
        }

        private async void NavigationTapped(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void OldPasswordVisibilityClicked(object sender, EventArgs e)
        {
            try
            {
                if (entryOldPassword.IsPassword)
                {
                    entryOldPassword.IsCustomPassword = false;
                    entryOldPassword.IsPassword = false;
                }
                else
                {
                    entryOldPassword.IsCustomPassword = true;
                    entryOldPassword.IsPassword = true;
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private void OldPasswordEdited(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(entryOldPassword.Text)))
                {
                    imageOldPasswordAccess.Opacity = 1;
                    imageOldPasswordAccess.IsEnabled = true;
                }
                else
                {
                    imageOldPasswordAccess.Opacity = 0;
                    imageOldPasswordAccess.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void NewPasswordVisibilityClicked(object sender, EventArgs e)
        {
            try
            {
                if (entryNewPassword.IsPassword)
                {
                    entryNewPassword.IsCustomPassword = false;
                    entryNewPassword.IsPassword = false;
                }
                else
                {
                    entryNewPassword.IsCustomPassword = true;
                    entryNewPassword.IsPassword = true;
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private void NewPasswordEdited(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(entryNewPassword.Text)))
                {
                    imageNewPasswordAccess.Opacity = 1;
                    imageNewPasswordAccess.IsEnabled = true;
                }
                else
                {
                    imageNewPasswordAccess.Opacity = 0;
                    imageNewPasswordAccess.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
        }

        private async void UpdateButtonClicked(object sender, EventArgs e)
        {
            try
            {
                var isValid = await IsFormValid();
                if (isValid)
                {
                    Navigation.PopModalAsync();
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
                if (string.IsNullOrEmpty(entryOldPassword.Text))
                {
                    await DisplayAlertMessage("Old password cannot be empty");
                }
                else if (string.IsNullOrEmpty(entryNewPassword.Text))
                {
                    await DisplayAlertMessage("New password cannot be empty");
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