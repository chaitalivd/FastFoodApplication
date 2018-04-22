using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delicioso.Interface
{
    public interface ISQLite_main
    {
        SQLiteConnection GetConnection();
    }
}
