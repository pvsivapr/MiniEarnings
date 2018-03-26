using System;

using Xamarin.Forms;

namespace YenCash
{
    public class CustomEntryView : ContentView
    {
        public CustomEntry entry;// { get; set; }
        public BoxView box;// { get; set; }
        public Label label;// { get; set; }
        //public StackLayout holder;// { get; set; }
        public Image image;// { get; set; }
        public StackLayout mainHolder;// { get; set; }

        public CustomEntryView()
        {
            var screenHeight = (BaseContentPage.screenHeight * 1) / 100;
            var screenWidth = (BaseContentPage.screenWidth * 1) / 100;

            entry = new CustomEntry()
            {
                Placeholder="Enter Name Here",
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            box = new BoxView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            label = new Label()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start
            };
            image = new Image()
            {
                Source = ImageSource.FromFile("AsteriskOneOrange.png"),//ImageSource.FromFile("ExclamationOne.png"),
                IsVisible = false,
                BackgroundColor = Color.Yellow,
                HeightRequest = (screenWidth * 10),
                WidthRequest = (screenWidth * 10),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Grid gridHolder = new Grid()
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = GridLength.Auto }
                },
                RowSpacing = 0,
                ColumnSpacing = 0,
                Padding = new Thickness(0, 0, 2, 0),
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            gridHolder.Children.Add(entry, 0, 0);
            gridHolder.Children.Add(image, 1, 0);
            mainHolder = new StackLayout()
            {
                Children = { gridHolder },
                Padding = new Thickness(1, 1, 1, 1),
                BackgroundColor = Color.Yellow,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Content = mainHolder;
        }
    }
}

