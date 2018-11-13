using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("DOMENA")]
    public class DomenaEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("VRSTADOMENE")]
        public string VrstaDomene { get; set; }

        [Column("NAZIV")]
        public string Naziv { get; set; }

        [Column("OZNAKA")]
        public string Oznaka { get; set; }

        [Column("PARENTID")]
        [ForeignKey("Parent")]
        public long ParentId { get; set; }

        public virtual DomenaEF Parent { get; set; }

        public virtual ICollection<DomenaEF> SadrzaneDomene { get; set; }
        public virtual ICollection<SudionikEF> Sudionici { get; set; }
        public virtual ICollection<UpisnikEF> Tijela { get; set; }
        public virtual ICollection<DokumentPismenoEF> DokumentiUPismenima { get; set; }
        public virtual ICollection<PismenoVrstaEF> Grupe { get; set; }
        public virtual ICollection<OsobaEF> VrsteOsoba { get; set; }

    }
}
