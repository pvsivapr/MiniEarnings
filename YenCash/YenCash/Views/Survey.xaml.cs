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
    public partial class Survey : ContentPage
    {
        string pageType;
        public Survey(string[] pageSettings)
        {
            InitializeComponent();
            pageType = pageSettings[0];
            if (pageType == "MasterPage")
            {
                imageMainNavigation.Source = ImageSource.FromFile("MenuHamBurger.png");
            }
            else
            {
                imageMainNavigation.Source = ImageSource.FromFile("LeftArrowWhite.png");
            }
        }

        private async void NavigationTapped(object sender, EventArgs e)
        {
            //stackLoader.IsVisible = true;
            try
            {
                if (pageType == "MasterPage")
                {
                    var ParentPage = (MasterDetailPage)this.Parent;
                    ParentPage.IsPresented = (ParentPage.IsPresented == false) ? true : false;
                }
                else
                {
                    Navigation.PopModalAsync(false);
                }
            }
            catch (Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            //stackLoader.IsVisible = false;
        }
    }
}