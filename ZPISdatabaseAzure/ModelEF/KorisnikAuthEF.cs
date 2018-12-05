using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPISdatabaseAzure.Model
{
    [Table("KORISNIKAUTH")]
    public class KorisnikAuthEF : BaseModel
    {
        [Key]
        [Column("ID")]
        public long Id { get; set; }

        [ForeignKey("Korisnik")]
        [Column("KORISNIKID")]
        public long KorisnikId { get; set; }

        [Column("AUTHTOKEN")]
        [MaxLength(255)]
        public string AuthToken { get; set; }

        [Column("DATUM")]
        public DateTime Datum { get; set; }

        public virtual KorisnikEF Korisnik { get; set; }
    }
}
