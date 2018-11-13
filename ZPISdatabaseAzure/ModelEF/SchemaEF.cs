using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPISdatabaseAzure.Model
{
    [Table("SCHEMA")]
    public class SchemaEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("NAZIV")]
        [MaxLength(200)]
        public string Naziv { get; set; }

        [Column("OZNAKA")]
        [MaxLength(20)]
        public string Oznaka { get; set; }

        public virtual ICollection<SchemaDokumentaEF> SchemeDokumenta { get; set; }
    }
}
