using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPISdatabaseAzure.Model
{
    [Table("SCHEMADOKUMENTA")]
    public class SchemaDokumentaEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("VERZIJA")]
        public long Verzija { get; set; }

        [Column("JSONSCHEMA")]
        public string JsonSchema { get; set; }

        [Column("NAZIVPREDLOSKADMS")]
        [MaxLength(255)]
        public string NazivPredloskaDMS { get; set; }

        [Column("SCHEMAID")]
        [ForeignKey("Schema")]
        public long SchemaId { get; set; }

        public virtual SchemaEF Schema { get; set; }

        public virtual ICollection<DokumentEF> Dokumenti { get; set; }
    }
}
