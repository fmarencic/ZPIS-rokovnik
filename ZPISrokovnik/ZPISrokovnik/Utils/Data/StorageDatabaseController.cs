using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;
using ZPISrokovnik.Utils;
using ZPISrokovnik.Views.Kalendar;

namespace ZPISrokovnik.Utils.Data
{
    public class StorageDatabaseController
    {
        static object locker = new object();

        private SQLiteConnection Database;

        public StorageDatabaseController()
        {
            this.Database = DependencyService.Get<ISQLite>().GetConnection();
            this.Database.CreateTable<Napomena>();
        }

        /// <summary>
        /// vraća prvi element
        /// </summary>
        /// <returns></returns>
        public Napomena DohvatiNapomenu()
        {
            lock (locker)
            {
                if (Database.Table<Napomena>().Count() == 0)
                {
                    return null;
                }
                return this.Database.Table<Napomena>().First();
            }
        }

        /// <summary>
        /// vraca listu napomena
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Napomena> DohvatiSveNapomene()
        {
            lock (locker)
            {
                if (Database.Table<Napomena>().Count() == 0)
                {
                    return null;
                }

                var _listaNapomena = this.Database.Table<Napomena>().ToList().OrderBy(napomena=>napomena.Datum);
                ObservableCollection<Napomena> listaNapomena = new ObservableCollection<Napomena>(_listaNapomena);
                return listaNapomena;
                //return this.Database.Table<Napomena>().ToList();
            }
        }


        /// <summary>
        /// update i insert -- ova
        /// </summary>
        /// <param name="napomena"></param>
        /// <returns></returns>
        public int SpremiNapomenu(Napomena napomena)
        {
            lock (locker)
            {
                if (napomena.Id != 0)
                {
                    this.Database.Update(napomena);
                    return napomena.Id;
                }
                return this.Database.Insert(napomena);
            }
        }

        public int ObrisiNapomenu(int id)
        {
            lock (locker)
            {
                return this.Database.Delete<Napomena>(id);
            }
        }
    }
}
