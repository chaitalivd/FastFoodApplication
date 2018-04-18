using FastFoodApp.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FastFoodApp.Models
{
    public class CartQuery
    {
        static object locker = new object();

        SQLiteConnection s;

        public CartQuery()
        {
            s = DependencyService.Get<SQlite_main>().GetConnection();
            s.CreateTable<CartRecord>();
        }

        //Insert 
        public int InsertDetails(CartRecord custDB)
        {
            lock (locker)
            {
                return s.Insert(custDB);
            }
        }

        //Update 
        public int UpdateDetails(CartRecord custDB)
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
                return s.Delete<CartRecord>(id);
            }
        }

        //Get all 
        public IEnumerable<CartRecord> GetList()
        {
            lock (locker)
            {
                return (from i in s.Table<CartRecord>() select i).ToList();
            }
        }


        public int GetTotal()
        {
            int gtot = 0;
            lock (locker)
            {
                List<CartRecord> items = (from i in s.Table<CartRecord>() select i).ToList();

                foreach (CartRecord x in items)
                {
                    gtot += Convert.ToInt32(x.Total);

                }
            }
            return gtot;
        }

        //Dispose
        public void Dispose()
        {
            s.Dispose();
        }
    }
}