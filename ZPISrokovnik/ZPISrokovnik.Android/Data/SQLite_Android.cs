using System.IO;
using Xamarin.Forms;
using ZPISrokovnik.Droid.Data;
using ZPISrokovnik.Utils;

[assembly: Dependency(typeof(SQLite_Android))]

namespace ZPISrokovnik.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "napomene.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}