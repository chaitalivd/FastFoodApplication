using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FastFoodApp.Droid.Interface;
using FastFoodApp.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(Sqlite_Android))]
namespace FastFoodApp.Droid.Interface
{
    public class Sqlite_Android : SQlite_main
    {
        public Sqlite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var filename = "Products.db";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}