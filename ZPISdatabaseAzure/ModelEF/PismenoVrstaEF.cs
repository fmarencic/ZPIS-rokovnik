using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("PISMENOVRSTA")]
    public class PismenoVrstaEF : BaseModel
    {
        [Column("ID")]
        [Key]
        public long Id { get; set; }

        [Column("AKTIVAN")]
        public bool Aktivan { get; set; }

        [Column("OZNAKA")]
        [MaxLength(255)]
        public string Oznaka { get; set; }

        [Column("NAZIV")]
        [MaxLength(255)]
        public string Naziv { get; set; }

        [Column("NAZIVZADOSTAVNICU")]
        [MaxLength(200)]
        public string NazivZaDostavnicu { get; set; }

        [Column("NAZIVVRSTEPISMENA")]
        [MaxLength(255)]
        public string NazivVrstePismena { get; set; }

        [Column("GRUPAID")]
        [ForeignKey("Grupa")]
        public long GrupaId { get; set; }

        public virtual DomenaEF Grupa { get; set; }

        public virtual ICollection<PismenoEF> Pismena { get; set; }
       

    }
}
