using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Delicioso.iOS.Interface;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteIOS))]
namespace Delicioso.iOS.Interface
{
    public class SqliteIOS : SQlite_main
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var fileName = "Menu.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var connection = new SQLite.SQLiteConnection(path);

            return connection;
        }
    }
}