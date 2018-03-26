using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace YenCash
{
    public class CustomCarouselView : View
    {
        public CustomCarouselView() { }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IList), typeof(CustomCarouselView), null,
            propertyChanged: (bindableObject, oldValue, newValue) =>
            {
                var carousel = (CustomCarouselView)bindableObject;
                if (carousel.ItemsSourceChanged != null)
                    carousel.ItemsSourceChanged();
            });

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(CustomCarouselView), null);

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty PositionProperty = BindableProperty.Create("Position", typeof(int), typeof(CustomCarouselView), 0);

        public int Position
        {
            get { return (int)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        // iOS only
        public static readonly BindableProperty BouncesProperty = BindableProperty.Create("Bounces", typeof(bool), typeof(CustomCarouselView), true);

        public bool Bounces
        {
            get { return (bool)GetValue(BouncesProperty); }
            set { SetValue(BouncesProperty, value); }
        }

        // UWP only
        public static readonly BindableProperty ArrowsProperty = BindableProperty.Create("Arrows", typeof(bool), typeof(CustomCarouselView), false);

        public bool Arrows
        {
            get { return (bool)GetValue(ArrowsProperty); }
            set { SetValue(ArrowsProperty, value); }
        }

        // Page Indicators properties
        public static readonly BindableProperty PageIndicatorsProperty = BindableProperty.Create("PageIndicators", typeof(bool), typeof(CustomCarouselView), false);

        public bool PageIndicators
        {
            get { return (bool)GetValue(PageIndicatorsProperty); }
            set { SetValue(PageIndicatorsProperty, value); }
        }

        public static readonly BindableProperty PageIndicatorBackgroundColorProperty = BindableProperty.Create("PageIndicatorBackgroundColor", typeof(Color), typeof(CustomCarouselView), Color.Transparent);

        public Color PageIndicatorBackgroundColor
        {
            get { return (Color)GetValue(PageIndicatorBackgroundColorProperty); }
            set { SetValue(PageIndicatorBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty PageIndicatorTintColorProperty = BindableProperty.Create("PageIndicatorTintColor", typeof(Color), typeof(CustomCarouselView), Color.Silver);

        public Color PageIndicatorTintColor
        {
            get { return (Color)GetValue(PageIndicatorTintColorProperty); }
            set { SetValue(PageIndicatorTintColorProperty, value); }
        }

        public static readonly BindableProperty CurrentPageIndicatorTintColorProperty = BindableProperty.Create("CurrentPageIndicatorTintColor", typeof(Color), typeof(CustomCarouselView), Color.Gray);

        public Color CurrentPageIndicatorTintColor
        {
            get { return (Color)GetValue(CurrentPageIndicatorTintColorProperty); }
            set { SetValue(CurrentPageIndicatorTintColorProperty, value); }
        }

        // Android and iOS only
        public static readonly BindableProperty InterPageSpacingProperty = BindableProperty.Create("InterPageSpacing", typeof(int), typeof(CustomCarouselView), 0);

        public int InterPageSpacing
        {
            get { return (int)GetValue(InterPageSpacingProperty); }
            set { SetValue(InterPageSpacingProperty, value); }
        }

        public static readonly BindableProperty OrientationProperty = BindableProperty.Create("Orientation", typeof(Orientation), typeof(CustomCarouselView), Orientation.Horizontal);

        public Orientation Orientation
        {
            get { return (Orientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        public Action ItemsSourceChanged;

        public EventHandler PositionSelected;

        public Action<int> RemoveAction;

        public void RemovePage(int position)
        {
            if (RemoveAction != null)
                RemoveAction(position);
        }

        public Action<object, int> InsertAction;

        public void InsertPage(object item, int position = -1)
        {
            if (InsertAction != null)
                InsertAction(item, position);
        }

        public Action<int> SetCurrentAction;

        public void SetCurrentPage(int position)
        {
            if (SetCurrentAction != null)
                SetCurrentAction(position);
        }
    }

    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public class LabelHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || (double)value < 0)
                return 0;

            var width = (double)value;
            var label = (Label)parameter;
            var height = DependencyService.Get<ITextMeter>().MeasureTextSize(label.Text, width, label.FontSize, label.FontFamily);

            return height;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITextMeter
    {
        double MeasureTextSize(string text, double width, double fontSize, string fontName = null);
    }
}

