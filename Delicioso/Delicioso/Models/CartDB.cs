using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delicioso.Models
{
    public class CartDB
    {
        [PrimaryKey, AutoIncrement, Column("ID")]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Username { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Qty { get; set; }
        public string Total { get; set; }
        public string Image { get; set; }
        public CartDB()
        {
        }
    }
}