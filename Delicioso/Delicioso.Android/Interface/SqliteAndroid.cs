using System.IO;
using Delicioso.Droid.Interface;
using Delicioso.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqliteAndroid))]
namespace Delicioso.Droid.Interface
{
    public class SqliteAndroid : ISQLite_main
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