using System;
using MiniEarnings;
using MiniEarnings.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRender))]
namespace MiniEarnings.iOS
{
	public class CustomDatePickerRender : DatePickerRenderer
	{
		public CustomDatePickerRender() { }

		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);

			try
			{
				CustomDatePicker element = Element as CustomDatePicker;
				if (e.NewElement != null)
				{
					element = Element as CustomDatePicker;
				}
				else
				{
					element = e.OldElement as CustomDatePicker;
				}

				if (Control != null)
				{
					//var element = Element as CustomDatePicker;
					var textGiven = element.EnterText;
					Control.BorderStyle = UITextBorderStyle.None;
					Control.AdjustsFontSizeToFitWidth = true;
					Control.Layer.CornerRadius = 10;
					Control.ExclusiveTouch = true;
					if (!string.IsNullOrWhiteSpace(textGiven))
					{
						Control.Text = textGiven;
					}
					Control.TextColor = UIColor.Black;
                    if (element.CustomFontFamily == "MontserratBold")
                    {
                        Control.Font = UIFont.FromName("Montserrat-Bold.ttf", 20.0f);
                    }
                    else if (element.CustomFontFamily == "MontserratLight")
                    {
                        Control.Font = UIFont.FromName("Montserrat-Light.ttf", 20.0f);
                    }
                    else
                    {
                        Control.Font = UIFont.FromName("Montserrat-Regular.ttf", 20.0f);
                    }
					if (element.CustomFontSize != 0)
					{
						UIFont font = Control.Font.WithSize(element.CustomFontSize);
						Control.Font = font;
					}
					else
					{
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
			try
			{
				CustomDatePicker element = Element as CustomDatePicker;

				if (Control != null)
				{
					//var element = Element as CustomDatePicker;
					var textGiven = element.EnterText;
					Control.BorderStyle = UITextBorderStyle.None;
					Control.AdjustsFontSizeToFitWidth = true;
					Control.Layer.CornerRadius = 10;
					Control.ExclusiveTouch = true;
					if (!string.IsNullOrWhiteSpace(textGiven))
					{
						//Control.Text = textGiven;
					}
					Control.TextColor = UIColor.Black;
                    if (element.CustomFontFamily == "MontserratBold")
                    {
                        Control.Font = UIFont.FromName("Montserrat-Bold.ttf", 20.0f);
                    }
                    else if (element.CustomFontFamily == "MontserratLight")
                    {
                        Control.Font = UIFont.FromName("Montserrat-Light.ttf", 20.0f);
                    }
                    else
                    {
                        Control.Font = UIFont.FromName("Montserrat-Regular.ttf", 20.0f);
                    }
					if (element.CustomFontSize != 0)
					{
						UIFont font = Control.Font.WithSize(element.CustomFontSize);
						Control.Font = font;
					}
					else
					{
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


