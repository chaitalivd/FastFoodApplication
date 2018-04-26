using Delicioso.Interface;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Delicioso.Model
{
    public class UserQuery
    {
        static object locker = new object();
        SQLiteConnection s;

        public UserQuery()
        {
            s = DependencyService.Get<ISQLite_main>().GetConnection();
            s.CreateTable<UserDB>();
        }

        //Insert 
        public int InsertDetails(UserDB userDB)
        {
            lock (locker)
            {
                List<UserDB> items = (from p in s.Table<UserDB>() where p.Username == userDB.Username select p).ToList();
                if(items.Count > 0)
                {
                    return -1;
                }
                else
                {
                    return s.Insert(userDB);
                }                
            }
        }

        //Get specific customer by ID
        public UserDB GetCustName(string name)
        {
            lock (locker)
            {
                return s.Table<UserDB>().LastOrDefault(t => t.Username.Equals(name));
            }
        }
    }
}