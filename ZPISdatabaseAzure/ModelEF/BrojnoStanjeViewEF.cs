using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZPISdatabaseAzure.Model
{
    [Table("BROJNOSTANJE_VIEW")]
    public class BrojnoStanjeViewEF : BaseModel
    {   
        [Key]
        [Column("TIJELOID")]
        public long TijeloId { get; set; }

        [Column("NAZIVTIJELA")]
        [MaxLength(255)]
        public string NazivTijela { get; set; }

        [Column("BROJZATVORENIKAMUSKI")]
        public long? BrojZatvorenikaMuski { get; set; }

        [Column("BROJZATVORENIKAZENSKI")]
        public long? BrojZatvorenikaZenski { get; set; }

        [Column("BROJISTRAZNIHZATVORENIKAMUSKI")]
        public long? BrojIstraznihZatvorenikaMuski { get; set; }

        [Column("BROJISTRAZNIHZATVORENIKAZENSKI")]
        public long? BrojIstraznihZatvorenikaZenski { get; set; }

        [Column("BROJKAZNJENIKAMUSKI")]
        public long? BrojKaznjenikaMuski { get; set; }

        [Column("BROJKAZNJENIKAZENSKI")]
        public long? BrojKaznjenikaZenski { get; set; }

        [Column("PROLAZNIMUSKU")]
        public long? ProlazniMuski { get; set; }

        [Column("NAIZLASKUMUSKI")]
        public long? NaIzlaskuMuski { get; set; }

        [Column("NAIZLASKUZENSKI")]
        public long? NaIzlaskuZenski { get; set; }

        [Column("UBIJEGUMUSKI")]
        public long? UBijeguMuski { get; set; }

        [Column("UBIJEGUZENSKI")]
        public long? UBijeguZenski { get; set; }

        [Column("NAPREKIDMUSKI")]
        public long? NaPrekidMuski { get; set; }

        [Column("NAPREKIDZENSKI")]
        public long? NaPrekidZenski { get; set; }
    }
}
