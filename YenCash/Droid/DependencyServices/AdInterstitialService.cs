using System;
using Android.Gms.Ads;
using YenCash.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdInterstitialService))]
namespace YenCash.Droid
{
    public class AdInterstitialService : IAdInterstitial
    {
        InterstitialAd interstitialAd;

        public AdInterstitialService()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context);

            // TODO: change this id to your admob id
            //interstitialAd.AdUnitId = "ca-app-pub-3940256099942544/1033173712";
            interstitialAd.AdUnitId = "ca-app-pub-4755254281656446/1206271019";
            LoadAd();
        }

        void LoadAd()
        {
            var requestbuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestbuilder.Build());
        }

        public void ShowAd()
        {
            if (interstitialAd.IsLoaded)
            {
                interstitialAd.Show();
            }

            LoadAd();
        }
    }
}

