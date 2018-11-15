using System;
using System.Collections.Generic;
using System.Text;

namespace ZPISdatabaseAzure.Repozitorij
{
    public interface IRepozitorij<T> where T : class
    {
        T DohvatiPoId(int id);

        List<T> DohvatiPoTijelu(int tijeloId);

    }
}
