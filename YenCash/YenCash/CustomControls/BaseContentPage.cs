using System;
using System.Threading.Tasks;
using Xamarin.Forms;

#region Created by Sivaprasad

namespace YenCash
{
	public class BaseContentPage : ContentPage
	{
		public AbsoluteLayout contentLayout;
		public ActivityIndicator aiLoader;
        public StackLayout PageLoading, PageControlsStackLayout, PageToast ;
        public Label loadingInfo, loadingInfoToast;
        //CustomGradientRoundEdgeView alertView;
        StackLayout alertView;
        const int toastTimer = 2500;
        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();

		public static int screenHeight, screenWidth;

		public BaseContentPage()
		{
			this.BackgroundColor = Color.Transparent;

			aiLoader = new ActivityIndicator
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
				Color = Color.White,
				IsEnabled = true,
				IsVisible = true,
				IsRunning = true,
			};

			contentLayout = new AbsoluteLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
			};
            loadingInfo = new Label()
            {
                Text = "",
                TextColor = Color.Black,
                IsVisible = false,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            loadingInfoToast = new Label()
            {
                Text = "Poor internet Connection",
                TextColor = Color.White,
                FontSize = (screenWidth * 5) / 100,
                BackgroundColor = Color.Transparent,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Button loadInfoToast = new Button()
            {
                Text = "Poor internet Connection",
                TextColor = Color.White,
                FontSize = (screenWidth * 4.5) / 100,
                BackgroundColor = Color.Black,
                BorderRadius = 20,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //StackLayout stackInfoHolder = new StackLayout()
            //{
            //    Children = {loadingInfoToast},
            //    HeightRequest = 50,
            //    WidthRequest = 200,
            //    BackgroundColor = Color.Yellow,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand

            //};


            /*
            CustomToastView alertsView = new CustomToastView()
            {
                Children = { loadInfoToast },
                HeightRequest = (screenHeight * 7) / 100,
                WidthRequest = (screenWidth * 70) / 100,
                //StartColor = Color.FromHex("#000000"),
                //EndColor = Color.FromHex("#000000"),
                //gradientMode = "Vertical",
                //cornerRadius = (Device.RuntimePlatform == "iOS") ? (HeightRequest = ((screenHeight * 7) / 100) / 2) : ((screenHeight * 7) / 100),
                IsVisible = true,
                //Opacity = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            */


            alertView = new StackLayout()
            {
                //Children = { alertsView },
                HeightRequest = (screenHeight * 10) / 100,
                WidthRequest = (screenWidth * 70) / 100,
                BackgroundColor = Color.Transparent,
                IsVisible = true,
                Opacity = 0,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };


            switch(Device.RuntimePlatform)
            {
                case "Android":
                    HeightRequest = (screenHeight * 10) / 100;
                    break;
                case "iOS":
                    HeightRequest = ((screenHeight * 10) / 100) / 2;
                    break;
                default:
                    break;
            };

            PageToast = new StackLayout
            {
                Children = { alertView },
                BackgroundColor = Color.Transparent,
                IsVisible = false,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            StackLayout _PageLoading = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Spacing = 20,
                Children = { aiLoader, loadingInfo }
            };
			PageLoading = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.FromRgba(0, 0, 0, 0.4),
                Spacing = 20,
				IsVisible = false,
                Children = { _PageLoading }
			};

			PageControlsStackLayout = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
				Spacing = 0
			};
			AbsoluteLayout.SetLayoutFlags(PageControlsStackLayout, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(PageControlsStackLayout, new Rectangle(0, 0, 1, 1));
			contentLayout.Children.Add(PageControlsStackLayout);

			AbsoluteLayout.SetLayoutFlags(PageLoading, AbsoluteLayoutFlags.All);
			AbsoluteLayout.SetLayoutBounds(PageLoading, new Rectangle(0.5, 0.5, 1, 1));
			contentLayout.Children.Add(PageLoading);

            AbsoluteLayout.SetLayoutFlags(PageToast, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(PageToast, new Rectangle(0.5, 0.02, 0.7, 0.078));
            contentLayout.Children.Add(PageToast);

			Content = contentLayout;

		}

        int i = 0;
        private bool ShowAlert()
        {
            try
            {
                if(stopWatch.ElapsedMilliseconds > toastTimer)
                {
                    if(i == 0)
                    {
                        loadingInfo.Text = "Your internet connection may be slow. \n please wait \n .";
                        i++;
                    }
                    else if(i == 1)
                    {
                        loadingInfo.Text += ".";
                        i++;
                    }
                    else if(i == 2)
                    {
                        loadingInfo.Text += ".";
                        i++;
                    }
                    else
                    {
                        loadingInfo.Text += ".";
                        i = 0;
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
            return stopWatch.IsRunning;
        }

        public async void AccessLoader(bool Access)
        {
            try
            {
                if (Access)
                {
                    loadingInfo.IsVisible = true;
                    PageLoading.IsVisible = true;

                    //if (!stopWatch.IsRunning)
                    //{
                    //    stopWatch.Start();
                    //    Device.StartTimer(new TimeSpan(0, 0, 0, 0, toastTimer), ShowToast);
                    //}
                }
                else
                {
                    loadingInfo.Text = "";
                    loadingInfo.IsVisible = false;
                    PageLoading.IsVisible = false;

                    //if (stopWatch.IsRunning)
                    //{
                    //    stopWatch.Reset();
                    //    stopWatch.Stop();
                    //}
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                System.Diagnostics.Debug.WriteLine(ex.Message+"\n"+ex.StackTrace);
            }
        }

        private bool ShowToast()
        {
            try
            {
                StartToast();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                System.Diagnostics.Debug.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
            return false;
        }

        async void StartToast()
        {
            try
            {
                if (stopWatch.IsRunning)
                {
                    PageToast.IsVisible = true;
                    alertView.FadeTo(1, 1000, Easing.Linear);

                    await Task.Delay(1500);

                    alertView.FadeTo(0, 1000, Easing.Linear);
                    PageToast.IsVisible = false;
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                System.Diagnostics.Debug.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}

#endregion