using System;
using MiniEarnings;
using MiniEarnings.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Graphicss = Android.Graphics;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRender))]
namespace MiniEarnings.Droid
{
	public class CustomLabelRender : LabelRenderer
	{
		public CustomLabelRender() { }

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			base.OnElementChanged(e);

			try
			{
				CustomLabel element = Element as CustomLabel;
				if (e.NewElement != null)
				{
					element = Element as CustomLabel;
				}
				else
				{
					element = e.OldElement as CustomLabel;
				}

				if (Control != null)
				{
					if (!string.IsNullOrWhiteSpace(element.CustomFontColor))
					{
						Control.SetTextColor(Graphicss.Color.ParseColor(element.CustomFontColor));
					}

                    if (element.CustomFontFamily == "MontserratBold")
                    {
                        Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "Montserrat-Bold.ttf");
                        Control.Typeface = font;
                    }
                    else if (element.CustomFontFamily == "MontserratLight")
                    {
                        Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "Montserrat-Light.ttf");
                        Control.Typeface = font;
                    }
                    else
                    {
                        Graphicss.Typeface font = Graphicss.Typeface.CreateFromAsset(Forms.Context.Assets, "Montserrat-Regular.ttf");
                        Control.Typeface = font;
                    }
				}
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
			}
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
		}
	}
}

