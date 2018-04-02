using System;
using Xamarin.Forms;

namespace YenCash
{
	public interface IShareService
	{
		void Share(string subject, string message, ImageSource image);
	}
}
