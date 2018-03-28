using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using YenCash;
using YenCash.Droid;
using Xamarin.Forms;
using System.IO;
using SQLite;
using SQLite.Net;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_Android))]
namespace YenCash.Droid
{	
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        { } 

        public SQLiteConnection GetConnection()
        { 
            var sqliteFilename = "incalert.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); 
			// Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
             var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLiteConnection(plat,path);
            // Return the database connection
            return conn;
        }
    }
}