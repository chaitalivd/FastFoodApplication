using Delicioso.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Delicioso.Models
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
                return s.Insert(userDB);
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