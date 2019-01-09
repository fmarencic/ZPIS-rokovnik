using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("KORISNIK")]
    public class KorisnikEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("KORISNICKOIME")]
        [MaxLength(200)]
        public string KorisnickoIme { get; set; }

        [Column("ZAPOSLENNATIJELIMA")]
        [MaxLength(2000)]
        public string ZaposlenNaTijelima { get; set; }

        [Column("LOZINKA")]
        [MaxLength(200)]
        public string Lozinka { get; set; }

        public virtual ICollection<KalendarEF> Kalendari { get; set; }
        public virtual ICollection<KorisnikUlogaEF> UlogeKorisnika { get; set; }
        public virtual ICollection<KorisnikAuthEF> AutentikacijeKorisnika { get; set; }

    }
}
