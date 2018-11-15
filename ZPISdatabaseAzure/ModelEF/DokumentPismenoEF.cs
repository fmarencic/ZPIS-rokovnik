using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("DOKUMENTPISMENO")]
    public class DokumentPismenoEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("PISMENOID")]
        [ForeignKey("Pismeno")]
        public long PismenoId { get; set; }

        [Column("DOKUMENTID")]
        [ForeignKey("Dokument")]
        public long DokumentId { get; set; }

        [Column("VRSTADOKUMENTAUPISMENUID")]
        [ForeignKey("VrstaDokumentaUPismenu")]
        public long VrstaDokumentaUPismenuId { get; set; }


        public virtual PismenoEF Pismeno { get; set; }
        public virtual DokumentEF Dokument { get; set; }
        public virtual DomenaEF VrstaDokumentaUPismenu { get; set; }
    }
}
