using FastFoodApp.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FastFoodApp.Models
{
    public class UserQuery
    {
        static object locker = new object();

        SQLiteConnection s;

        public UserQuery()
        {
            s = DependencyService.Get<SQlite_main>().GetConnection();
            s.CreateTable<UserDB>();
        }

        //Insert 
        public int InsertDetails(UserDB custDB)
        {
            lock (locker)
            {
                return s.Insert(custDB);
            }
        }

        //Update 
        public int UpdateDetails(UserDB custDB)
        {
            lock (locker)
            {
                return s.Update(custDB);
            }
        }

        //Delete 
        public int DeleteNote(int id)
        {
            lock (locker)
            {
                return s.Delete<UserDB>(id);
            }
        }

        //Get all 
        public IEnumerable<UserDB> GetCustomerList()
        {
            lock (locker)
            {
                return (from i in s.Table<UserDB>() select i).ToList();
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

        //Dispose
        public void Dispose()
        {
            s.Dispose();
        }
    }
}
