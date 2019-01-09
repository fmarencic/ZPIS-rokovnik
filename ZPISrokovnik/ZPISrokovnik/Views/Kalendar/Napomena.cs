using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ZPISrokovnik.Views.Kalendar
{
    /// <summary>
    /// za display 
    /// </summary>
    public class Napomena
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
                "Napomena tjeralica",
                "Napomena preprata",
                "Napomena najava"
            };
        
        public Napomena()
        {
        }

        public Napomena(DateTime datum, string naziv, string opis)
        {
            this.Datum = datum;
            this.Naziv = naziv;
            this.Opis = opis;
        }

    }
}
