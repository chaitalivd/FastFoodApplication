using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delicioso.Interface
{
    public interface SQlite_main
    {
        SQLiteConnection GetConnection();
    }
}
