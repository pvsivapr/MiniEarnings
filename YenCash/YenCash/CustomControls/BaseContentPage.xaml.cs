using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YenCash
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseContentPage : ContentPage
    {
        public ContentView viewMainHolder;
        public static int screenHeight, screenWidth;
        public BaseContentPage()
        {
            screenWidth = (screenWidth * 1 )/ 100;
            screenHeight = (screenHeight * 1) / 100;
            
            viewMainHolder = new ContentView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            InitializeComponent();
            stackMainHolder.Children.Add(viewMainHolder);
        }
    }
}