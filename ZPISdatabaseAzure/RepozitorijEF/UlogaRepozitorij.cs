using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPISdatabaseAzure.Model;

namespace ZPISdatabaseAzure.Repozitorij
{
    public class UlogaRepozitorij : IUlogaRepozitorij
    {
        public UlogaEf DohvatiPoId(int id)
        {
            throw new NotImplementedException();
        }

        public List<UlogaEf> DohvatiPoTijelu(int tijeloId)
        {
            throw new NotImplementedException();
        }

        public List<UlogaEf> DohvatiUlogePoKorisniku(long korisnikID)
        {
            throw new NotImplementedException();
        }
    }
}
