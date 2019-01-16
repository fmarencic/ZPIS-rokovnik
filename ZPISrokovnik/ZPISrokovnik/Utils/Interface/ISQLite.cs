using SQLite;

namespace ZPISrokovnik.Utils
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
