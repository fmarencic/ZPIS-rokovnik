using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPISdatabaseAzure.Model;
using ZPISdatabaseAzure.Repozitorij;

namespace ZPISdatabaseAzure.Repozitorij
{
    public interface IUlogaRepozitorij : IRepozitorij<UlogaEf>
    {
        List<UlogaEf> DohvatiUlogePoKorisniku(long korisnikID);
    }
}
