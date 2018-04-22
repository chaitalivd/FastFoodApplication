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
            s = DependencyService.Get<ISQLite_main>().GetConnection();
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
            int n = 0;
            int count = 0;
            lock (locker)
            {
                List<CartDB> items = (from p in s.Table<CartDB>() where p.Username == user select p).ToList();
                foreach(CartDB x in items)
                {
                    n = x.Id;
                    count += s.Delete<CartDB>(n);
                }
                return count;
                //s.Delete(result);
                //var result = from p in s.Table<CartDB>() where p.Username == user select p;
                //s.Delete(result);
                //return s.Delete<CartDB>(user);
                //return s.Query<CartDB>("delete from CartDB where Username='" + user + "'").AsEnumerable();
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