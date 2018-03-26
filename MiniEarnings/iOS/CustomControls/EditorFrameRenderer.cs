using System;
using CoreGraphics;
using MiniEarnings;
using MiniEarnings.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EditorFrame), typeof(EditorFrameRenderer))]
namespace MiniEarnings.iOS
{
	public class EditorFrameRenderer : FrameRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
		{
			base.OnElementChanged(e);
			this.Layer.CornerRadius = 2;
			//this.Layer.Bounds.Inset(1, 1);
			Layer.BorderColor = UIColor.FromRGB(114, 114, 114).CGColor;
			//Layer.BackgroundColor = UIColor.FromRGB(224, 224, 224).CGColor;
			Layer.BorderWidth = 2;
			//Layer.BackgroundColor = Color.Transparent.ToCGColor();
		}
	}
}
