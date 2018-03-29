using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            var imageMetrices = width * 38;

            imageProfilePic.HeightRequest = imageMetrices;
            imageProfilePic.WidthRequest = imageMetrices;

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

                /*
                IList<String> buttons = new List<String>();
                buttons.Add(ChooseImageFrom.Gallery.ToString());
                buttons.Add(ChooseImageFrom.Camera.ToString());

                var action = await DisplayActionSheet("Choose photo from", "Cancel", null, buttons.ToArray());

                if (action == ChooseImageFrom.Camera.ToString())
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                        {
                            return;
                        }

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

                        imglist = new List<byte>();

                        cropedBytes = await CrossXMethod.Current.CropImageFromOriginalToBytes(file.Path);

                        if (cropedBytes != null)
                        {
                            foreach (var item in cropedBytes)
                            {
                                imglist.Add(item); ;
                            }
                        }

                        if (cropedBytes != null)
                        {
                            imageProfilePicImageSource = ImageSource.FromStream(() =>
                            {
                                var cropedImage = new MemoryStream(cropedBytes);
                                file.Dispose();
                                return cropedImage;
                            });
                            imageProfilePic.Source = imageProfilePicImageSource;
                        }
                        else
                        {
                            file.Dispose();
                            if (imgdata == null)
                            {
                                imageProfilePic.Source = "ProfileImage.png";
                            }
                            else
                            {
                                imageProfilePic.Source = ImageSource.FromStream(() => new MemoryStream(imgdata));
                            }
                        }
                    });
                }

                else if (action == ChooseImageFrom.Gallery.ToString())
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await CrossMedia.Current.Initialize();
                        if (!CrossMedia.Current.IsPickPhotoSupported)
                        {
                            return;
                        }
                        MediaFile file = await CrossMedia.Current.PickPhotoAsync();

                        if (file == null)
                        {
                            return;
                        }

                        imglist = new List<byte>();

                        cropedBytes = await CrossXMethod.Current.CropImageFromOriginalToBytes(file.Path);

                        if (cropedBytes != null)
                        {
                            foreach (var item in cropedBytes)
                            {
                                imglist.Add(item);
                            }
                        }


                        if (cropedBytes != null)
                        {
                            imageProfilePicImageSource = ImageSource.FromStream(() =>
                            {
                                var cropedImage = new MemoryStream(cropedBytes);
                                file.Dispose();
                                return cropedImage;
                            });
                            imageProfilePic.Source = imageProfilePicImageSource;
                        }

                        else
                        {
                            file.Dispose();
                            if (imgdata == null)
                            {
                                imageProfilePic.Source = "ProfileImage.png";
                            }
                            else
                            {
                                imageProfilePic.Source = ImageSource.FromStream(() => new MemoryStream(imgdata));
                            }
                        }
                    });
                }
                */
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
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
