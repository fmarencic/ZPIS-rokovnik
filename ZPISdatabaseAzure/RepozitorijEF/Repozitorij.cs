using System;
using System.Collections.Generic;
using System.Text;

namespace ZPISdatabaseAzure.Repozitorij
{
    public abstract class Repozitorij<T> : IRepozitorij<T> where T : class
    {
        public void Azuriraj(T entity)
        {
            throw new NotImplementedException();
        }

        public T DohvatiPoId(int id)
        {
            throw new NotImplementedException();
        }

        public void Izbrisi(T entity)
        {
            throw new NotImplementedException();
        }

        public void Unesi(T entity)
        {
            throw new NotImplementedException();
        }
    }

}
