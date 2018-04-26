using Delicioso.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Delicioso.Model
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
                List<CartDB> items = (from p in s.Table<CartDB>() where p.Name == cartDB.Name && p.Username == cartDB.Username select p).ToList();
                if(items.Count > 0)
                {
                    foreach(CartDB x in items)
                    {
                        int rQuantity = Convert.ToInt32(cartDB.Qty);
                        int dQuantity = Convert.ToInt32(x.Qty);
                        dQuantity += rQuantity;
                        x.Qty = dQuantity.ToString();

                        int rTotal = Convert.ToInt32(cartDB.Total);
                        int dTotal = Convert.ToInt32(x.Total);
                        dTotal += rTotal;
                        x.Total = dTotal.ToString();

                        return s.Update(x);
                    }
                }
                else
                {
                    return s.Insert(cartDB);
                }
                return 0;
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
            int count = 0;
            lock (locker)
            {
                List<CartDB> items = (from p in s.Table<CartDB>() where p.Username == user select p).ToList();
                foreach (CartDB x in items)
                {
                    int n = x.Id;
                    count += s.Delete<CartDB>(n);
                }
                return count;
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

        public int GetTotal(string username)
        {
            int gtot = 0;
            lock (locker)
            {
                List<CartDB> items = (from i in s.Table<CartDB>() where i.Username == username select i).ToList();

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