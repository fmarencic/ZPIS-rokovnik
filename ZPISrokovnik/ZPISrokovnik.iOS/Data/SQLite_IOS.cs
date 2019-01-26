using System.IO;
using ZPISrokovnik.iOS.Data;
using ZPISrokovnik.Utils;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_IOS))]

namespace ZPISrokovnik.iOS.Data
{
    public class SQLite_IOS : ISQLite
    {
        public SQLite_IOS() { }

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFileName = "napomene.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var libaryPath = Path.Combine(documentPath, "..", "Libary");
            var path = Path.Combine(libaryPath, sqliteFileName);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}