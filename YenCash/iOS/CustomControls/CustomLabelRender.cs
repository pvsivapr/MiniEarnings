using System;
using YenCash;
using YenCash.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRender))]
namespace YenCash.iOS
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

					Control.ExclusiveTouch = true;
					//var element = Element as CustomLabel;
					if (!string.IsNullOrWhiteSpace(element.CustomFontColor))
					{
						//Control.TextColor = Color.FromHex(element.CustomFontColor).ToUIColor();
						//Control.TextColor = Color.FromHex("#00A6CC").ToUIColor();
						//Control.TextColor = Color.FromHex(element.CustomFontColor).ToCGColor();
					}
					//Control.TextColor = UIColor.Black;
					//for place holder
					//var entry1 = new Entry();
					//Control.Layer.BorderColor = Color.FromHex("#0000").ToCGColor();
					//Control.Layer.BorderWidth = 0;
					//entry1.Layer.BorderWidth = 1f;
                    var fSize = (element.FontSize == 0) ? 20.0f : ((nfloat)(element.FontSize));
                    if (element.CustomFontFamily == "MontserratBold")
                    {
                        Control.Font = UIFont.FromName("Montserrat-Bold", fSize);
                    }
                    else if (element.CustomFontFamily == "MontserratLight")
                    {
                        Control.Font = UIFont.FromName("Montserrat-Light", fSize);
                    }
                    else
                    {
                        Control.Font = UIFont.FromName("Montserrat-Regular", fSize);
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

