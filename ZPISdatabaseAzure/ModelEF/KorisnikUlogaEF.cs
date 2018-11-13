using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("KORISNIKULOGA")]
    public class KorisnikUlogaEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("ULOGAID")]
        [ForeignKey("Uloga")]
        public long UlogaId { get; set; }

        [Column("KORISNIKID")]
        [ForeignKey("Korisnik")]
        public long KorisnikId { get; set; }

        public virtual KorisnikEF Korisnik { get; set; }
        public virtual UlogaEf Uloga { get; set; }
    }
}
