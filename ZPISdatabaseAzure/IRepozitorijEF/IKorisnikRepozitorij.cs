using ZPISdatabaseAzure.Model;
using ZPISdatabaseAzure.Repozitorij;

namespace ZPISdatabaseAzure
{
    public interface IKorisnikRepozitorij : IRepozitorij<KorisnikEF>
    {
        KorisnikEF LogIn(string KorisnickoIme, string Lozinka);
    }
}
