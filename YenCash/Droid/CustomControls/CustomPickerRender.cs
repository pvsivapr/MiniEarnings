using System;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Util;
using YenCash;
using YenCash.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Graphicss = Android.Graphics;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRender))]
namespace YenCash.Droid
{
	public class CustomPickerRender : PickerRenderer
	{
		public CustomPickerRender(){}

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			try
			{
				CustomPicker element = Element as CustomPicker;
				if (e.NewElement != null)
				{
					element = Element as CustomPicker;
				}
				else
				{
					element = e.OldElement as CustomPicker;
				}

				if (Control != null)
				{
					GradientDrawable gd = new GradientDrawable();
					//gd.SetCornerRadius(45); // increase or decrease to changes the corner look
					gd.SetColor(global::Android.Graphics.Color.Transparent);
					//gd.SetStroke(2, global::Android.Graphics.Color.Gray);
					this.Control.SetBackgroundDrawable(gd);
					this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
					//Control.Text = element.EnterText;
					Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.Black));//for placeholder
																										   //this.Control.InputType = InputTypes.TextVariationPassword;
					if (element.CustomFontSize != 0.0)
					{
						Control.SetTextSize(ComplexUnitType.Dip, element.CustomFontSize);
						//Control.SetTextSize(Android.Util.ComplexUnitType.Dip, element.CustomFontSize);
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
	}
}

