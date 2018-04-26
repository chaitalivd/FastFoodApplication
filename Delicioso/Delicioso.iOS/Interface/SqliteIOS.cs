using System;
using System.IO;
using Delicioso.iOS.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteIOS))]
namespace Delicioso.iOS.Interface
{
    public class SqliteIOS
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