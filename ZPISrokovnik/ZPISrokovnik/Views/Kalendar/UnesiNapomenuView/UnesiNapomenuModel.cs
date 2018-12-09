using System;
using System.Collections.Generic;
using System.Text;

namespace ZPISrokovnik.Views.Kalendar
{
    public class UnesiNapomenuModel
    {
        public DateTime Datum { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public UnesiNapomenuModel()
        {
            
        }

        public UnesiNapomenuModel(DateTime datum, string naziv, string opis)
        {
            this.Datum = datum;
            this.Naziv = naziv;
            this.Opis = opis;
        }
    }
}
