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
				Source = "http://superwall.us/wallpaper/proposing_love_machine_rose_horse_robo_lady-oCrC.jpg",//"http://www.wintellect.com/devcenter/wp-content/uploads/2013/10/Wintellect_logo.gif",
				Aspect = Aspect.AspectFit
			};

			sharebutton.Clicked += (sender, e) =>
			{
				DependencyService.Get<IShareService>().Share(" ", "Hi Gopi. How are you?", img.Source);
			};

			StackLayout stack = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.Aqua,
				Children = { sharebutton }
			};

			Content = stack;
			Padding = new Thickness(0, 20, 0, 0);
		}
	}
}

