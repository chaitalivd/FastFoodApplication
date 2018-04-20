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
using Delicioso.Droid.Interface;
using Delicioso.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteAndroid))]
namespace Delicioso.Droid.Interface
{
    public class SqliteAndroid : SQlite_main
    {
        public SqliteAndroid() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var filename = "Menu.db";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }
    }
}