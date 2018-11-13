using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    public class BaseModel
    {
        [Column("KREIRAO")]
        [Required]
        [MaxLength(100)]
        public string Kreirao { get; set; }

        [Column("KREIRAOVRIJEME")]
        public DateTime KreiraoVrijeme { get; set; }

        [Column("PROMIJENIO")]
        [MaxLength(100)]
        public string Promijenio { get; set; }

        [Column("PROMIJENIOVRIJEME")]
        public DateTime? PromijenioVrijeme { get; set; }

        [Column("NAPOMENA")]
        public string Napomena { get; set; }
    }
}
