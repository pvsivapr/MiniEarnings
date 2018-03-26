using System;
using Android.App;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Text;
using Android.Util;
using YenCash;
using YenCash.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Graphicss = Android.Graphics;


[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(CustomTimePickerRender))]
namespace YenCash.Droid
{
	public class CustomTimePickerRender : TimePickerRenderer, TimePickerDialog.IOnTimeSetListener, IJavaObject, IDisposable
	{

		public CustomTimePickerRender() { }

		private TimePickerDialog dialog = null;

		protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
		{
			base.OnElementChanged(e);

			try
			{
				CustomTimePicker element = Element as CustomTimePicker;
				if (e.NewElement != null)
				{
					element = Element as CustomTimePicker;
				}
				else
				{
					element = e.OldElement as CustomTimePicker;
				}

				if (Control != null)
				{


					#region TimePicker 24H
					this.SetNativeControl(new Android.Widget.EditText(Forms.Context));
					this.Control.Click += Control_Click;
					this.Control.Text = "00:00";
					this.Control.KeyListener = null;
					this.Control.FocusChange += Control_FocusChange;

					#endregion

					GradientDrawable gd = new GradientDrawable();
					//gd.SetCornerRadius(45); // increase or decrease to changes the corner look
					gd.SetColor(global::Android.Graphics.Color.Transparent);
					//gd.SetStroke(2, global::Android.Graphics.Color.Gray);
					this.Control.SetBackgroundDrawable(gd);
					this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
					if (!string.IsNullOrWhiteSpace(element.EnterText))
					{
						Control.Text = element.EnterText;
					}
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
		void Control_FocusChange(object sender, Android.Views.View.FocusChangeEventArgs e)
		{
			if (e.HasFocus)
				ShowTimePicker();
		}

		void Control_Click(object sender, EventArgs e)
		{
			ShowTimePicker();
		}

		private void ShowTimePicker()
		{
			if (dialog == null)
			{
				dialog = new TimePickerDialog(Forms.Context, this, DateTime.Now.Hour, DateTime.Now.Minute, true);
			}

			dialog.Show();
		}

		public void OnTimeSet(Android.Widget.TimePicker view, int hourOfDay, int minute)
		{
			var time = new TimeSpan(hourOfDay, minute, 0);
			this.Element.SetValue(Xamarin.Forms.TimePicker.TimeProperty, time);

			this.Control.Text = time.ToString(@"hh\:mm");
		}

	}
}

