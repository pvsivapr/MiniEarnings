using System;
using MiniEarnings;
using MiniEarnings.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomBadge), typeof(CustomBadgeRenderer))]
namespace MiniEarnings.Droid
{
	public class CustomBadgeRenderer : FrameRenderer
	{
        public CustomBadgeRenderer(){}
		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);
			this.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.Badge_Rect));
		}
	}
}
