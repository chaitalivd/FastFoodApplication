using FastFoodApp.Interface;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FastFoodApp.Models
{
    public class ProductsQuery
    {
        static object locker = new object();
        SQLiteConnection sqlcon;

        public ProductsQuery()
        {
            sqlcon = DependencyService.Get<SQlite_main>().GetConnection();
            sqlcon.CreateTable<ProductsDB>();

        }

        public int InsertDetails(ProductsDB notesDB)
        {
            lock (locker)
            {
                return sqlcon.Insert(notesDB);
            }
        }

        public int GetNoOfProducts()
        {
            lock (locker)
            {
                return (from i in sqlcon.Table<ProductsDB>() select i).ToList().Count;
            }
        }

        public IEnumerable<ProductsDB> GetProductList()
        {
            lock (locker)
            {
                return (from i in sqlcon.Table<ProductsDB>() select i).ToList();
            }
        }
    }
}