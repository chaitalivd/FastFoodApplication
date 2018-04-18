using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFoodApp.Interface
{
    public interface SQlite_main
    {
        SQLiteConnection GetConnection();
    }
}
