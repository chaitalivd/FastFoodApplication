using Delicioso.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Delicioso.Models
{
    public class CartQuery
    {
        static object locker = new object();

        SQLiteConnection s;

        public CartQuery()
        {
            s = DependencyService.Get<SQlite_main>().GetConnection();
            s.CreateTable<CartDB>();
        }

        //Insert 
        public int InsertDetails(CartDB cartDB)
        {
            lock (locker)
            {
                return s.Insert(cartDB);
            }
        }

        //Delete 
        public int DeleteNote(int id)
        {
            lock (locker)
            {
                return s.Delete<CartDB>(id);
            }
        }
        public int DeleteCart(string user)
        {
            lock (locker)
            {
               return s.Delete<CartDB>(user);
            }
        }

        //Get all 
        public IEnumerable<CartDB> GetList(string username)
        {
            lock (locker)
            {
                var query = from cust in s.Table<CartDB>() where cust.Username == username select cust;
                return query.AsEnumerable();
            }
        }

        public int GetTotal()
        {
            int gtot = 0;
            lock (locker)
            {
                List<CartDB> items = (from i in s.Table<CartDB>() select i).ToList();

                foreach (CartDB x in items)
                {
                    gtot += Convert.ToInt32(x.Total);

                }
            }
            return gtot;
        }

        public int GetNoOfProducts()
        {
            lock (locker)
            {
                return (from i in s.Table<CartDB>() select i).ToList().Count;
            }
        }

    }
}