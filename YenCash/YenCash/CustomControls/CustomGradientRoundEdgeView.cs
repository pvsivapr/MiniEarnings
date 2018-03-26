using System;

using Xamarin.Forms;

namespace YenCash
{
    public class CustomGradientRoundEdgeView : StackLayout
    {
        public CustomGradientRoundEdgeView() { }

        public string gradientMode { get; set; }
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
        public double cornerRadius { get; set; }
        public bool HasBorderColor { get; set; }
        public Color BorderColor { get; set; }
    }
}

