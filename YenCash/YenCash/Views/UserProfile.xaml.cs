using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace YenCash
{
    public partial class UserProfile : ContentPage
    {
        public UserProfile()
        {
            InitializeComponent();

            var height = (App.screenHeight * 1) / 100;
            var width = (App.screenWidth * 1) / 100;

            pageTitle.FontSize = width * 6;

            var imageMetrices = width * 38;

            imageProfilePic.HeightRequest = imageMetrices;
            imageProfilePic.WidthRequest = imageMetrices;

            entryUserMobile.TextChanged += MobileNumberEdited;

            //viewMainHolder.Content = AbsHolder;
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

        private async void UpdateButtonClicked(object sender, EventArgs e)
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
                else if (string.IsNullOrEmpty(entryUserLastName.Text))
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

        //private async void RightNavigationTapped(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Navigation.PopModalAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        PrintLog.PublishLog(ex);
        //    }
        //}

        #region for ProfilePic Tapped event
        ImageSource AvatarImageSource;
        //byte[] imgdata;
        //List<byte> imglist;
        //byte[] cropedBytes;
        private async void ProfilePicTapped(object sender, EventArgs e)
        {
            try
            {
                IList<String> buttons = new List<String>();
                buttons.Add(ChooseImageFrom.Gallery.ToString());
                buttons.Add(ChooseImageFrom.Camera.ToString());

                var action = await DisplayActionSheet("Choose photo from", "Cancel", null, buttons.ToArray());

                if (action == ChooseImageFrom.Camera.ToString())
                {
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        return;
                    }
                    await Task.Delay(100);
                    MediaFile file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        DefaultCamera = CameraDevice.Rear,
                        Directory = "OnePosInventory",
                        Name = "Media.jpg"
                    });

                    if (file == null)
                    {
                        return;
                    }

                    byte[] cropedBytes = await CrossXMethod.Current.CropImageFromOriginalToBytes(file.Path);

                    if (cropedBytes != null)
                    {
                        AvatarImageSource = ImageSource.FromStream(() =>
                        {
                            var cropedImage = new MemoryStream(cropedBytes);
                            file.Dispose();
                            return cropedImage;
                        });
                        imageProfilePic.Source = AvatarImageSource;
                    }
                    else
                    {
                        file.Dispose();
                    }

                }
                else if (action == ChooseImageFrom.Gallery.ToString())
                {
                    await CrossMedia.Current.Initialize();
                    if (!CrossMedia.Current.IsPickPhotoSupported)
                    {
                        return;
                    }
                    await Task.Delay(100);
                    MediaFile file = await CrossMedia.Current.PickPhotoAsync();

                    if (file == null)
                    {
                        return;
                    }

                    byte[] cropedBytes = await CrossXMethod.Current.CropImageFromOriginalToBytes(file.Path);

                    if (cropedBytes != null)
                    {
                        AvatarImageSource = ImageSource.FromStream(() =>
                        {
                            var cropedImage = new MemoryStream(cropedBytes);
                            file.Dispose();
                            return cropedImage;
                        });
                        imageProfilePic.Source = AvatarImageSource;
                    }

                    else
                    {
                        file.Dispose();
                    }

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
        #endregion
    }

    public enum ChooseImageFrom
    {
        Camera,
        Gallery
    }
}
