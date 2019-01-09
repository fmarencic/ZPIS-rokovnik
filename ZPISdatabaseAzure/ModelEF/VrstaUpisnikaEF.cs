using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("VRSTAUPISNIKA")]
    public class VrstaUpisnikaEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("NAZIVGRUPE")]
        [MaxLength(200)]
        public string NazivGrupe { get; set; }

        [Column("OZNAKA")]
        [MaxLength(255)]
        public string Oznaka { get; set; }

        [Column("OZNAKABROJ")]
        public long OznakaBroj { get; set; }

        [Column("AKTIVAN")]
        public bool Aktivan { get; set; }

        [Column("REDNIBROJ")]
        public long? RedniBroj { get; set; }

        [Column("PRIPADAVRSTIUPISNIKAID")]
        public long? PripadaVrstiUpisnikaId { get; set; }

        public virtual VrstaUpisnikaEF PripadaVrstiUpisnika { get; set; }

        public virtual ICollection<VrstaUpisnikaEF> VrsteUpisnikaPripadaju { get; set; }

        public virtual ICollection<UpisnikEF> Upisnici { get; set; }


    }
}
