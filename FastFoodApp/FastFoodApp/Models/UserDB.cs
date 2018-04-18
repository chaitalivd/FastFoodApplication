using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodApp.Models
{
    public class UserDB
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        public UserDB()
        {
        }
    }
}