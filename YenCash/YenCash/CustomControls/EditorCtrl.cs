using System;
using Xamarin.Forms;

namespace YenCash
{
	public class EditorCtrl : Editor
	{

		public static readonly BindableProperty PlaceholderProperty =
			BindableProperty.Create<EditorCtrl, string>(view => view.Placeholder, String.Empty);

		public string Placeholder
		{
			get
			{
				return (string)GetValue(PlaceholderProperty);
			}

			set
			{
				SetValue(PlaceholderProperty, value);
			}
		}

	}
}
