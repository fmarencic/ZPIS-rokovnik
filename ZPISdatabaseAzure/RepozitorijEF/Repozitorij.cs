using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ZPISdatabaseAzure.Repozitorij
{
    public abstract class Repozitorij<T, C> : IRepozitorij<T> where T : class, new() where C : DbContext
    {
        private string databaseName = "ZPISRokovnikDatabaseContext";

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public void SetDatabaseName(string DatabaseName) => this.DatabaseName = DatabaseName;

        public T DohvatiPoId(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> DohvatiPoTijelu(int tijeloId)
        {
            throw new NotImplementedException();
        }
    }

}
