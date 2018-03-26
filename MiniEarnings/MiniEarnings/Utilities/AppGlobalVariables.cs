using System;
using System.Collections.Generic;
using Xamarin.Forms;

#region Created by SivaPrasad

namespace MiniEarnings
{
    public class AppGlobalVariables
    {
       
        public static string fontFamilyReg = "MontseRegular";
        public static string fontFamilyLight = "MontserratLight";
        public static string fontFamilyBold = "MontserratBold";

        public static double smallFont = (BaseContentPage.screenWidth * 3.0) / 100;//3.5) / 100;
        public static double largeFont = (BaseContentPage.screenWidth * 6.2) / 100;//6.5) / 100;
        public static double veryLargeFont = (BaseContentPage.screenWidth * 7.2) / 100;//7.5) / 100;

        public static double headingTitleSize = (BaseContentPage.screenWidth * 6.2) / 100;

        public static Color BackGroundColor = Color.Orange;

        public static Color HeadingTextColor = Color.White;

        public static Color TextColor = Color.Black;

        /*
        public static Color ReddishPink = Color.FromHex("#f95e78");
        public static Color orange = Color.FromHex("#F78F1E");
        public static Color btnOrange = Color.FromHex("#f7941f");
        public static Color blue = Color.FromHex("#2C97DF");
        public static Color red = Color.FromHex("#E55950");
        public static Color gray = Color.FromHex("#BFBFBF");
        public static Color black = Color.FromHex("#2C2C2C");
        public static Color White = Color.FromHex("#FFFFFF");
        public static Color lightBlack = Color.FromHex("#585858");
        public static Color lightMarron = Color.FromHex("##850029");
        public static Color darkMarron = Color.FromHex("#4B0000");
        public static Color viewlightMarron = Color.FromHex("#6D0018");
        public static Color lightBlue = Color.FromHex("#004491");
        public static Color fontVeryThick = Color.FromHex("#303030");
        public static Color fontMediumThick = Color.FromHex("#505050");
        public static Color fontLessThick = Color.FromHex("#707070");
        public static Color lightGray = Color.FromHex("#F5F5F5");
        public static Color underLineColor = Color.FromHex("#999999");
        */
        /*
        #region for gradient Colors
        public static Color violetShadeLight = Color.FromHex("#5e6ae4");
        public static Color violetShadeDark = Color.FromHex("#9144e7");
        public static Color greenShadeLight = Color.FromHex("#3dbee1");
        public static Color greenShadeDark = Color.FromHex("#14c35d");
        public static Color redShadeLight = Color.FromHex("#c40799");
        public static Color redShadeDark = Color.FromHex("#fd504c");
        public static Color orangeShadeLight = Color.FromHex("#f9a85d");
        public static Color orangeShadeDark = Color.FromHex("#f95e78");
        #endregion
        */


        public static string NetWorkMsg = "Please check your network access";
        public static string _annonymousMessage = "Server error please try again";

    }

    public class GradientColors
    {
        public int ColorIndex { get; set; }
        public string ColorGroupName { get; set; }
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }
    }
}



#endregion