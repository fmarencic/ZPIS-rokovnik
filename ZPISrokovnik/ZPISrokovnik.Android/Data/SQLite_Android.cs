using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Nio.FileNio;
using Xamarin.Forms;
using ZPISrokovnik.Droid.Data;
using ZPISrokovnik.Utils.Interface;

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