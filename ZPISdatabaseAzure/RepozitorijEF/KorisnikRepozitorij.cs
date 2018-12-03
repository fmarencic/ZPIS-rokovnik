using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPISdatabaseAzure.Model;
using ZPISdatabaseAzure.Repozitorij;

namespace ZPISdatabaseAzure
{
    public class KorisnikRepozitorij : Repozitorij<KorisnikEF>,  IKorisnikRepozitorij
    {
        public KorisnikRepozitorij(ZPISRokovnikDatabaseContext ctx) : base(ctx)
        {

        }

        public KorisnikEF LogIn(string KorisnickoIme, string Lozinka)
        {
            try
            {
                var korisnik = (from x in ZPISRokovnikDbContext.Korisnik where x.KorisnickoIme.ToLower() == KorisnickoIme select x);

                if (korisnik.Count() > 1)
                    throw new Exception();

                if (korisnik.Count() == 0)
                    throw new Exception();

                if ((string.IsNullOrWhiteSpace(Lozinka)) || korisnik.Single().Lozinka.ToLower() != Lozinka.ToLower())
                    throw new Exception();

                var k = korisnik.Single();
                return k;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }
    }
}
