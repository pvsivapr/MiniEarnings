using System;
using YenCash;
using YenCash.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomBadge), typeof(CustomBadgeRenderer))]
namespace YenCash.iOS
{
	public class CustomBadgeRenderer : FrameRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);
			this.Layer.CornerRadius = 10;
			//this.Layer.Bounds.Inset(1, 1);
			Layer.BorderColor = UIColor.FromRGB(75, 0, 0).CGColor;
			Layer.BackgroundColor = UIColor.FromRGB(75, 0, 0).CGColor;
			Layer.BorderWidth = 2;
			//Layer.BackgroundColor = Color.Transparent.ToCGColor();
		}
	}
}

