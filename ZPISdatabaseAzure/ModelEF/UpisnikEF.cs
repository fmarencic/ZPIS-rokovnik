using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("UPISNIK")]
    public class UpisnikEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("NAZIV")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        [Column("VRSTAUPISNIKAID")]
        [ForeignKey("VrstaUpisnika")]
        public long VrstaUpisnikaId { get; set; }

        [Column("OZNAKA")]
        [MaxLength(255)]
        public string Oznaka { get; set; }

        [Column("GODINA")]
        public long Godina { get; set; }

        [Column("AKTIVAN")]
        public bool Aktivan { get; set; }

        [Column("TIJELOID")]
        [ForeignKey("Tijelo")]
        public long TijeloId { get; set; }

        public virtual OsobaEF Tijelo { get; set; }
        public virtual VrstaUpisnikaEF VrstaUpisnika { get; set; }



        public virtual ICollection<PredmetEF> Predmeti { get; set; }
    }
}
