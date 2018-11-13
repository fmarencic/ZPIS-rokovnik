using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPISdatabaseAzure.Model
{
    [Table("PISMENO")]
    public class PismenoEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("REDNIBROJ")]
        public long RedniBroj { get; set; }

        [Column("NAZIVVRSTEPISMENA")]
        [MaxLength(255)]
        public string NazivVrstePismena { get; set; }

        [Column("URBROJ")]
        [MaxLength(40)]
        public string UrBroj { get; set; }

        [Column("PREDMETID")]
        [ForeignKey("Predmet")]
        public long PredmetId { get; set; }

        [Column("PISMENOVRSTAID")]
        [ForeignKey("PismenoVrsta")]
        public long PismenoVrstaId { get; set; }

        public virtual PredmetEF Predmet { get; set; }
        public virtual PismenoVrstaEF PismenoVrsta { get; set; }

        public virtual ICollection<DokumentPismenoEF> PismenaUDokumentima { get; set; }
        
    }
}
