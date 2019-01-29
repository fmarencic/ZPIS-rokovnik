using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("PREDMET")]
    public class PredmetEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("REDNIBROJ")]
        public long RedniBroj { get; set; }

        [Column("NAZIV")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        [Column("DATUMOSNIVANJA")]
        public DateTime? DatumOsnivanja { get; set; }

        [Column("OZNAKAPREDMETA")]
        [MaxLength(255)]
        public string OznakaPredmeta { get; set; }

        [Column("UPISNIKID")]
        [ForeignKey("Upisnik")]
        public long UpisnikId { get; set; }

        [Column("STATUSPREDMETAID")]
        [ForeignKey("StatusPredmeta")]
        public long? StatusPredmetaId { get; set; }

        [Column("TIJELOID")]
        [ForeignKey("Tijelo")]
        public long? TijeloId { get; set; }


        public virtual DomenaEF StatusPredmeta { get; set; }
        public virtual UpisnikEF Upisnik { get; set; }
        public virtual OsobaEF Tijelo { get; set; }

        public virtual ICollection<SudionikEF> Sudionici { get; set; }

        public virtual ICollection<KalendarEF> Kalendari { get; set; }

        public virtual ICollection<PismenoEF> Pismena { get; set; }

        
    }
}
