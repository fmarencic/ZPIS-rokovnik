using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using ZPISrokovnik.Utils.Interface;
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
            this.Database.CreateTable<NapomenaModel>();
        }

        /// <summary>
        /// vraća prvi element
        /// </summary>
        /// <returns></returns>
        public NapomenaModel DohvatiNapomenu()
        {
            lock (locker)
            {
                if (Database.Table<NapomenaModel>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return this.Database.Table<NapomenaModel>().First();
                }
            }
        }

        /// <summary>
        /// vraca listu napomena
        /// </summary>
        /// <returns></returns>
        public List<NapomenaModel> DohvatiSveNapomene()
        {
            lock (locker)
            {
                if (Database.Table<NapomenaModel>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return this.Database.Table<NapomenaModel>().ToList();
                }
            }
        }


        /// <summary>
        /// update i insert -- ova
        /// </summary>
        /// <param name="napomena"></param>
        /// <returns></returns>
        public int SpremiNapomenu(NapomenaModel napomena)
        {
            lock (locker)
            {
                if (napomena.Id != 0)
                {
                    this.Database.Update(napomena);
                    return napomena.Id;
                }
                else
                {
                    return this.Database.Insert(napomena);
                }
            }
        }

        public int ObrisiNapomenu(int id)
        {
            lock (locker)
            {
                return this.Database.Delete<NapomenaModel>(id);
            }
        }
    }
}
