using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPISdatabaseAzure.Model
{
    [Table("OSOBA")]
    public class OsobaEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("IME")]
        [MaxLength(255)]
        public string Ime { get; set; }

        [Column("PREZIME")]
        [MaxLength(255)]
        public string Prezime { get; set; }

        [Column("NAZIV")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        [Column("ADRESA")]
        [MaxLength(255)]
        public string Adresa { get; set; }

        [Column("EMAIL")]
        [MaxLength(255)]
        public string Email { get; set; }

        [Column("OIB")]
        [MaxLength(11)]
        public string OIB { get; set; }

        [Column("VRSTAOSOBEID")]
        [ForeignKey("VrstaOsobe")]
        public long VrstaOsobeId { get; set; }

        public virtual DomenaEF VrstaOsobe { get; set; }

        public virtual ICollection<SudionikEF> Sudionici { get; set; }
    }
}
