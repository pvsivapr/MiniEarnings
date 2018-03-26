using System;
using Xamarin.Forms;

namespace MiniEarnings
{
	public class CustomLabel : Label
	{
		public CustomLabel()
		{
		}

		public static readonly BindableProperty CustomFontFamilyProperty = BindableProperty.Create(propertyName: "CustomFontFamily", returnType: typeof(string), declaringType: typeof(CustomEntry), defaultValue: default(string));
		public string CustomFontFamily { get; set; }

		public static readonly BindableProperty CustomFontColorProperty = BindableProperty.Create(propertyName: "CustomFontSize", returnType: typeof(string), declaringType: typeof(CustomEntry), defaultValue: "#282828");
		public string CustomFontColor { get; set; }
	}
}
