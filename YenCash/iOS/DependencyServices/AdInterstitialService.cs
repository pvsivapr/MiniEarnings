using System;
using YenCash.iOS;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdInterstitialService))]
namespace YenCash.iOS
{
    public class AdInterstitialService : IAdInterstitial
    {
        Interstitial interstitial;
        public AdInterstitialService()
        {
            LoadAd();
            interstitial.ScreenDismissed += (s, e) => LoadAd();
        }

        void LoadAd()
        {
            // TODO: change this id to your admob id
            //interstitial = new Interstitial("ca-app-pub-3940256099942544/4411468910");
            interstitial = new Interstitial("ca-app-pub-4755254281656446/5636470615");
            var request = Request.GetDefaultRequest();
            interstitial.LoadRequest(request);
        }


        public void ShowAd()
        {
            if (interstitial.IsReady)
            {
                var viewController = UIApplication.SharedApplication.KeyWindow.RootViewController;
                interstitial.PresentFromRootViewController(viewController);
            }
        }
    }
}

