using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using YenCash.Droid;

[assembly: Dependency(typeof(ShareService))]
namespace YenCash.Droid
{
	public class ShareService : Activity, IShareService
    {
		public async void Share(string subject, string message, ImageSource image)
		{
            //await CheckAppPermissions();
            try
            {
                var intent = new Intent(Intent.ActionSend);
                //intent.PutExtra(Intent.ExtraSubject, subject);
                intent.PutExtra(Intent.ExtraText, message);
                intent.SetType("image/png");

                var handler = new ImageLoaderSourceHandler();
                var bitmap = await handler.LoadImageAsync(image, this);

                /*
                var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDownloads + Java.IO.File.Separator + "logo.png");

                using (var os = new System.IO.FileStream(path.AbsolutePath, System.IO.FileMode.Create))
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 100, os);
                }
                intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(path));
                Forms.Context.StartActivity(Intent.CreateChooser(intent, "Share Image"));
                
                */


                /*
                string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
                string folderName = "CurrentApp";
                var folderPath = System.IO.Path.Combine(documentPath, folderName);
                System.IO.Directory.CreateDirectory(folderPath);
                string fName = "Download.pdf";
                var localPath = System.IO.Path.Combine(folderPath, fName);
                using (var os = new System.IO.FileStream(localPath, System.IO.FileMode.Create))
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 100, os);
                }
                intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile((Java.IO.File)localPath));
                Forms.Context.StartActivity(Intent.CreateChooser(intent, "Share Image"));
                */


                //var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDownloads + Java.IO.File.Separator + "logo.png");

                var path = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryDownloads + Java.IO.File.Separator + "logo.png" + System.DateTime.Now.Ticks.ToString());

                using (var os = new System.IO.FileStream(path.AbsolutePath, System.IO.FileMode.Create))
                {
                    bitmap.Compress(Bitmap.CompressFormat.Png, 100, os);
                }
                intent.PutExtra(Intent.ExtraStream, Android.Net.Uri.FromFile(path));
                Forms.Context.StartActivity(Intent.CreateChooser(intent, "Share Image"));

            }
            catch(System.Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
		}

        private async Task<bool> CheckAppPermissions()
        {
            /*
            try
            {
                if ((int)Build.VERSION.SdkInt < 23)
                {
                    //return;
                }
                else
                {
                    if (PackageManager.CheckPermission(Manifest.Permission.ReadExternalStorage, PackageName) != Permission.Granted
                        && PackageManager.CheckPermission(Manifest.Permission.WriteExternalStorage, PackageName) != Permission.Granted)
                    {
                        var permissions = new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage };
                        RequestPermissions(permissions, 1);
                    }
                }
            }
            catch (System.Exception ex)
            {
                PrintLog.PublishLog(ex);
            }
            */
            return true;
        }
	}
}
