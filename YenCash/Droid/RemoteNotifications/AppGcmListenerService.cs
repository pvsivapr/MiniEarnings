
using Android.App;
using Android.Content;
using Android.OS;
using Android.Gms.Gcm;
using Android.Util;
using Xamarin.Forms;
using System;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;
using OnePosCRM.SQLiteDB.Connection;

namespace OnePosCRM.Droid
{
	[Service(Exported = false), IntentFilter(new[] { "com.google.android.c2dm.intent.RECEIVE" })]
	public class AppGcmListenerService : GcmListenerService
	{
		//public PostComments objSavePostComments;
		public override void OnMessageReceived(string from, Bundle objData)
		{

			//objSavePostComments = new PostComments();
			bool hasPushPayload = false;
			bool isPostNotification = false;
			try
			{
				if (objData != null)
				{
					string title = objData.GetString("title");
					string description = objData.GetString("alert");
					string alertId = objData.GetString("reminder_id");

					//Newtonsoft.Json.Linq.JToken values = Newtonsoft.Json.Linq.JObject.Parse(objData.GetString("Bundle")); 
					SendNotification(title, description,alertId);
				//SendNotification("IncAlert", "Notification from IncAlert");
				}
			}
			catch (Exception ex)
			{
				//LogInfo.ReportErrorInfo(ex.Message, ex.StackTrace, "AppGcmListenerService-OnMessageReceived");

			}

		}

		// Use Notification Builder to create and launch the notification:

		void SendNotification(string NotificationTitle, string NotificationAlert, string NotificationAlertId)
		{

			try
			{

				//MessageingCenter objMessageCenter = new MessageingCenter();
				//using (var iDatabaseMethods = new DatabaseMethods())
				//{
				//	if (hasPayload == true)
				//	{
				//		//iDatabaseMethods.SavePostComments(objSavePostComments);
				//		objMessageCenter.NotifyMessage();
				//		objMessageCenter.UnSubNotifyMessage();
				//	}

				//	if (isPostNotification == true)
				//	{
				//		//iDatabaseMethods.AddItemCount(1, "PC");
				//		objMessageCenter.NotifyPostMessage();
				//		objMessageCenter.UnSubNotifyPostMessage();
				//	}
				//};


				Random notifications = new Random();
				var notificationNo = notifications.Next(1, 9999);

				var intent = new Intent(this, typeof(MainActivity));
				intent.PutExtra("alertNotificationId", NotificationAlertId);
				intent.AddFlags(ActivityFlags.ClearTop);
				var pendingIntent = PendingIntent.GetActivity(this, notificationNo, intent, PendingIntentFlags.Immutable);

				var notificationBuilder = new Notification.Builder(this)
					.SetSmallIcon(Resource.Drawable.icon)
					.SetContentTitle(NotificationTitle)
					.SetContentText(NotificationAlert)
					.SetAutoCancel(true)
					.SetDefaults(NotificationDefaults.Sound)
					.SetContentIntent(pendingIntent);

				var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
				notificationManager.Notify(notificationNo, notificationBuilder.Build());

				try
				{
					
				}
				catch (Exception ex)
				{
					var msg = ex.Message;
				}



				//try
				//{
				//	if (App.isAppAwake == false)
				//	{
				//		Device.BeginInvokeOnMainThread(() =>
				//		{
				//			Constants.IsNotified = true;
				//			Constants.rem_Ids = NotificationAlertId;
				//			App.Current.MainPage = new EntityDetails(null, NotificationAlertId);
				//			App.isAppAwake = true;
				//		});
				//	}
				//	else
				//	{
				//	}
				//}
				//catch (Exception ex)
				//{
				//	var msg = ex.Message;
				//}

				//try
				//{
				//	Device.BeginInvokeOnMainThread(() =>
				//	{
				//		Constants.IsNotified = true;
				//		Constants.rem_Ids = NotificationAlertId;
				//		App.Current.MainPage = new EntityDetails(null, NotificationAlertId);
				//	});
				//}
				//catch (Exception ex)
				//{
				//	var msg = ex.Message;
				//}

				//App.Current.MainPage.Navigation.PushModalAsync(new EntityDetails(null,NotificationAlertId));
			}
			catch (Exception ex)
			{
				var msg = ex.Message;
				//LogInfo.ReportErrorInfo(ex.Message, ex.StackTrace, "AppGcmListenerService-SendNotification");

			}
		}

	}
}
