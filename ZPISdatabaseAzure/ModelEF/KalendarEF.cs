using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("KALENDAR")]
    public class KalendarEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("START")]
        public DateTime? Start { get; set; }

        [Column("KRAJ")]
        public DateTime? Kraj { get; set; }

        [Column("PREDMETID")]
        [ForeignKey("Predmet")]
        public long PredmetId { get; set; }

        [Column("KORISNIKID")]
        [ForeignKey("Korisnik")]
        public long KorisnikId { get; set; }

        public virtual KorisnikEF Korisnik { get; set; }

        public virtual PredmetEF Predmet { get; set; }
    }
}
