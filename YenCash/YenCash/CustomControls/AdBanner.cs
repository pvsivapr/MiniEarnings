using System;

using Xamarin.Forms;

namespace YenCash
{
    public class AdBanner : View
    {
        public AdBanner(){}
        public enum Sizes { Standardbanner, LargeBanner, MediumRectangle, FullBanner, Leaderboard, SmartBannerPortrait }
        public Sizes Size { get; set; }
    }
}

