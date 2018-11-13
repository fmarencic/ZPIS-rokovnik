using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("ULOGA")]
    public class UlogaEf : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("NAZIV")]
        [MaxLength(200)]
        public string Naziv { get; set; }

        public virtual ICollection<KorisnikUlogaEF> UlogeKorisnika { get; set; }

    }
}
