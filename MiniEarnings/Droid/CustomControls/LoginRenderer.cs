using Android.App;
using Xamarin.Forms.Platform.Android;
using MiniEarnings;
using Xamarin.Forms;
using System.Net;
using MiniEarnings.Droid;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using MiniEarnings.Droid;
using Xamarin.Auth;
using LinqToTwitter.Common;
using LinqToTwitter.Json;
using Android.Graphics;
using System.Security.Cryptography.X509Certificates;


[assembly: ExportRenderer(typeof(ProviderLoginPage), typeof(LoginRenderer))]
namespace MiniEarnings.Droid
{
	public class LoginRenderer : PageRenderer
	{
		bool showLogin = true;

		public static Xamarin.Auth.Account loggedInAccount { get; set; }

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);

			//Get and Assign ProviderName from ProviderLoginPage

			var loginPage = Element as ProviderLoginPage;
			string providername = loginPage.ProviderName;

			var activity = this.Context as Activity;
			if (showLogin && OAuthConfig.User == null)
			{
				showLogin = false;

				//Create OauthProviderSetting class with Oauth Implementation .Refer Step 6

				OAuthProviderSetting oauth = new OAuthProviderSetting();


				if (providername == "Twitter Login")
				{
					var auth = oauth.LoginWithTwitter();

					// After Twitter  login completed 
					auth.Completed += (sender, eventArgs) =>
					{
						if (eventArgs.IsAuthenticated)
						{
							OAuthConfig.User = new UserDetails();

							// Get and Save User Details 

							OAuthConfig.User.ConsumerKey = eventArgs.Account.Properties["oauth_consumer_key"];
							OAuthConfig.User.ConsumerSecret = eventArgs.Account.Properties["oauth_consumer_secret"];
							OAuthConfig.User.Token = eventArgs.Account.Properties["oauth_token"];
							OAuthConfig.User.TokenSecret = eventArgs.Account.Properties["oauth_token_secret"];
							OAuthConfig.User.TwitterId = eventArgs.Account.Properties["user_id"];
							OAuthConfig.User.ScreenName = eventArgs.Account.Properties["screen_name"];

							OAuthConfig.SuccessfulLoginAction.Invoke();

							// Here i would like to assign values to PostNeed Class members for Posting image purpose. I did it in Dependency service ITwitterService.s

							PostNeed.ConsumerKey = OAuthConfig.User.ConsumerKey;
							PostNeed.ConsumerSecret = OAuthConfig.User.ConsumerSecret;
							PostNeed.Token = OAuthConfig.User.Token;
							PostNeed.TokenSecret = OAuthConfig.User.TokenSecret;
							PostNeed.TwitterId = OAuthConfig.User.TwitterId;
							PostNeed.ScreenName = OAuthConfig.User.ScreenName;

							TwitterPage.twitterLoginTest = true;

							App.Current.MainPage = new TwitterPage(true);
						}
						else
						{
							// The user cancelled
						}
					};

					activity.StartActivity((Android.Content.Intent)auth.GetUI(activity));
				}
			}
		}
	}
}