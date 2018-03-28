
using System;
using Android.App;
using Android.Content;
using Android.Util;
using Android.Gms.Gcm;
using Xamarin.Forms;
using Java.Util;
using System.Collections.Generic;
using OnePosCRM.SQLiteDB.Connection;
using Android.Gms.Iid;

namespace OnePosCRM.Droid
{
	// This intent service receives the registration token from GCM:
	[Service(Exported = false)]
	class RegistrationIntentService : IntentService
	{
		// Notification topics that I subscribe to:
		static readonly string[] Topics = { "global" };

		// Create the IntentService, name the worker thread for debugging purposes:
		public RegistrationIntentService() : base("RegistrationIntentService")
		{ }

		// OnHandleIntent is invoked on a worker thread:
		protected override void OnHandleIntent(Intent intent)
		{
			try
			{
				Log.Info("RegistrationIntentService", "Calling InstanceID.GetToken");

				// Ensure that the request is atomic:
				lock (this)
				{
					// Request a registration token:
					var instanceID = InstanceID.GetInstance(this);
					var token = instanceID.GetToken(Constants.GCMSenderId, GoogleCloudMessaging.InstanceIdScope, null);

					// Log the registration token that was returned from GCM:
					Log.Info("RegistrationIntentService", "GCM Registration Token: " + token);

					// Send to the app server (if it requires it):
					SendRegistrationToAppServer(token);

					// Subscribe to receive notifications:
					SubscribeToTopics(token, Topics);
				}
			}
			catch (Exception ex)
			{
				//LogInfo.ReportErrorInfo(ex.Message, ex.StackTrace, "RegistrationIntentService-OnHandleIntent");

			}
		}

		void SendRegistrationToAppServer(string token)
		{
			// Add custom implementation here as needed.
			IDatabaseMethods objDB = new DatabaseMethods();
			var deviceUDID = UUID.RandomUUID().ToString();
			objDB.SaveDeviceToken(token, deviceUDID);
			var userInfo = objDB.GetUserInfo();
			var deviceInfo = objDB.GetDeviceToken();
			if (userInfo != null)
			{
                //fill info here
                /*
				IDeviceIdBAL objIDeviceBAL = new DeviceIdBAL();
				objIDeviceBAL.SendDeviceId(new DeviceIdReq { device_type = "android", udid = token, user_id = userInfo.UserId });
				*/
			} 
		}

		// Subscribe to topics to receive notifications from the app server:
		void SubscribeToTopics(string token, string[] topics)
		{
			foreach (var topic in topics)
			{
				var pubSub = GcmPubSub.GetInstance(this);
				pubSub.Subscribe(token, "/topics/" + topic, null);
			}
		}
	}
}
