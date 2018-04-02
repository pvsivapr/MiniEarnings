using System;

using Xamarin.Forms;

namespace YenCash
{
	public class SharePage : ContentPage
	{
		public SharePage()
		{
			Button sharebutton = new Button()
			{
				Text = "Share",
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				TextColor = Color.White,
				BackgroundColor = Color.Blue

			};

			Image img = new Image()
			{
                //Source = ImageSource.FromFile("RupeeTwo.png"),//"http://www.wintellect.com/devcenter/wp-content/uploads/2013/10/Wintellect_logo.gif",
                //Source = "http://superwall.us/wallpaper/proposing_love_machine_rose_horse_robo_lady-oCrC.jpg",
                //Source = "http://sunprairieumc.org/wp-content/uploads/2017/02/i-am-461820_640-png_1_20150917-965.png",
				Aspect = Aspect.AspectFit
            };
            var imageURL = "https://png.pngtree.com/element_origin_min_pic/16/08/17/0957b3bc4636f16.jpg";
            //var imageURL = "http://sunprairieumc.org/wp-content/uploads/2017/02/i-am-461820_640-png_1_20150917-965.png";

            img.Source = imageURL;
            //img.Source = new UriImageSource()
            //{
            //    CachingEnabled = false,
            //    Uri = new Uri(imageURL)
            //};

			sharebutton.Clicked += (sender, e) =>
			{
				DependencyService.Get<IShareService>().Share(" ", "Hi Sivaprasad. How are you?", img.Source);
			};

			StackLayout stack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Aqua,
                Children = { img, sharebutton }
			};

			Content = stack;
			Padding = new Thickness(0, 20, 0, 0);
		}
	}
}

