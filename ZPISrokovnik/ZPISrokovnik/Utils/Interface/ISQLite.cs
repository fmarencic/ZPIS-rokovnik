using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ZPISrokovnik.Utils.Interface
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
