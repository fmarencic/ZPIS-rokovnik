using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("DOKUMENT")]
    public class DokumentEF : BaseModel
    {
        #region Stupci

        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("KLASIFIKACIJSKAOZNAKA")]
        [MaxLength(2000)]
        public string KlasifikacijskaOznaka { get; set; }

        [Column("POSLOVNAOZNAKA")]
        [MaxLength(2000)]
        public string PoslovnaOznaka { get; set; }

        [Column("URUDZBENIBROJ")]
        [MaxLength(2000)]
        public string UrudzbeniBroj { get; set; }

        [Column("BROJSTRANICA")]
        public long? BrojStranica { get; set; }

        [Column("IMADIGITALIZIRANIDOKUMENT")]
        public bool ImaDigitaliziraniDokument { get; set; }

        [Column("DATUM")]
        public DateTime? Datum { get; set; }

        [Column("IMARADNIDOKUMENT")]
        public bool ImaRadniDokument { get; set; }

        [Column("DIGITALNIDOKUMENT")]
        public string DigitalniDokument { get; set; }

        [Column("NAZIVDOKUMENTADMS")]
        [MaxLength(255)]
        public string NazivDokumentaDMS { get; set; }

        [Column("SCHEMADOKUMENTAID")]
        [ForeignKey("SchemaDokumenta")]
        public long SchemaDokumentaId { get; set; }

        #endregion

        #region FK objekti i liste

        public virtual SchemaDokumentaEF SchemaDokumenta { get; set; }

        public virtual ICollection<DokumentPismenoEF> DokumentiUPismenu { get; set; }

        #endregion
    }
}
