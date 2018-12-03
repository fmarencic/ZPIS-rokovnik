using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ZPISdatabaseAzure.Repozitorij
{
    public abstract class Repozitorij<T> : IRepozitorij<T> where T : class
    {
        protected readonly ZPISRokovnikDatabaseContext ZPISRokovnikDbContext;

        public Repozitorij(ZPISRokovnikDatabaseContext ctx)
        {
            ZPISRokovnikDbContext = ctx;
        }

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
