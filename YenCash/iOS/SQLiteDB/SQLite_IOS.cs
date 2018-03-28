using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Foundation;
using UIKit;
using Xamarin.Forms;
using YenCash;
using SQLite.Net;
using YenCash.iOS;

[assembly: Dependency(typeof(SQLite_IOS))]
namespace YenCash.iOS
{
   
    public class SQLite_IOS :ISQLite
    {
        public SQLite_IOS() { }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "incalert.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var plat = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var conn = new SQLiteConnection(plat,path);
            // Return the database connection
            return conn;
        }
    }
}