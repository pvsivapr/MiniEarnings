using Android.App;
using Android.Content;

using Android.Gms.Iid;

namespace OnePosCRM.Droid
{
	[Service(Exported = false), IntentFilter(new[] { "com.google.android.gms.iid.InstanceID" })]
	class AppInstanceIDListenerService : InstanceIDListenerService
	{
		// When a token refresh happens, start my RegistrationIntentService:
		public override void OnTokenRefresh()
		{
			var intent = new Intent(this, typeof(RegistrationIntentService));
			StartService(intent);
		}
	}
}
