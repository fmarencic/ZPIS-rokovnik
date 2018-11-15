using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("OSOBAFOTOGRAFIJE")]
    public class OsobaFotografijeEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("FOTOGRAFIJA")]
        public string Fotografija { get; set; }

        [Column("TIP")]
        [MaxLength(255)]
        public string Tip { get; set; }

        [Column("OSOBAID")]
        [ForeignKey("Osoba")]
        public long OsobaId { get; set; }

        public virtual OsobaEF Osoba { get; set; }
    }
}
