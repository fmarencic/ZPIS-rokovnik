using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ZPISrokovnik.Views.Kalendar
{
    /// <summary>
    /// za display 
    /// </summary>
    public class NapomenaModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public bool Vidljivo { get; set; } = false;

        public List<string> Kalendari =
            new List<string>()
            {
                "Kalendar tjeralica",
                "Kalendar preprata",
                "Kalendar najava"
            };
        
        public NapomenaModel()
        {
        }

        public NapomenaModel(DateTime datum, string naziv, string opis)
        {
            this.Datum = datum;
            this.Naziv = naziv;
            this.Opis = opis;
        }

    }
}
