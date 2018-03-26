using MiniEarnings;
using MiniEarnings.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ProviderLoginPage), typeof(LoginRenderer))]
namespace MiniEarnings.iOS
{
	public class LoginRenderer : PageRenderer
	{
		bool showLogin = true;

		public override void ViewDidAppear(bool animated)
		{
			//Get and Assign ProviderName from ProviderLoginPage

			var loginPage = Element as ProviderLoginPage;
			string providername = loginPage.ProviderName;

			if (showLogin && OAuthConfig.User == null)
			{
				showLogin = false;


				//Create OauthProviderSetting class with Oauth Implementation .Refer Step 6

				OAuthProviderSetting oauth = new OAuthProviderSetting();


				if (providername == "Twitter Login")
				{
					var auth = oauth.LoginWithTwitter()
									;
					//TwitterPage.twitterLoginTest = true;

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

							// Here i would like to assign values to PostNeed Class for Posting image purpose. I did it in Dependency service

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
					PresentViewController(auth.GetUI(), true, null);
				}
			}
		}
	}
}