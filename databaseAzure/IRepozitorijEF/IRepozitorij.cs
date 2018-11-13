using System;
using System.Collections.Generic;
using System.Text;

namespace databaseAzure
{
    public interface IRepozitorij<T> where T : class
    {
        T DohvatiPoId(int id);
        void Unesi(T entity);
        void Izbrisi(T entity);
        void Azuriraj(T entity);
    }
}
