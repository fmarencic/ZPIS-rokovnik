using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("SUDIONIK")]
    public class SudionikEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("PREDMETID")]
        [ForeignKey("Predmet")]
        public long PredmetId { get; set; }

        [Column("OSOBAID")]
        [ForeignKey("Osoba")]
        public long OsobaId { get; set; }

        [Column("ULOGA")]
        [ForeignKey("Uloga")]
        public long UlogaId { get; set; }

        public virtual DomenaEF Uloga { get; set; }
        public virtual OsobaEF Osoba { get; set; }
        public virtual PredmetEF Predmet { get; set; }

    }
}
