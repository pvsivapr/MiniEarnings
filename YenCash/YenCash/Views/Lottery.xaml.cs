using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YenCash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lottery : ContentPage
    {
        public Lottery()
        {
            InitializeComponent();
        }

        private async void NavigationTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }
    }
}