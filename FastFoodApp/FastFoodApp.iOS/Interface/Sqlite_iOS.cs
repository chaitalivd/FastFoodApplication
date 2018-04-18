using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FastFoodApp.iOS.Interface;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqlite_iOS))]
namespace FastFoodApp.iOS.Interface
{
    public class Sqlite_iOS : SQlite_main
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "Products.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}