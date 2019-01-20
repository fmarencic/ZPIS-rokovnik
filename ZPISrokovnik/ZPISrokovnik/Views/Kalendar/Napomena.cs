using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using SQLite;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.Kalendar
{
    public class Napomena : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private DateTime datum;
        public DateTime Datum
        {
            get { return datum; }
            set
            {
                SetValue(ref datum, value);
                OnPropertyChanged(nameof(datum));
            }
        }

        private DateTime datumDo;
        public DateTime DatumDo
        {
            get { return datumDo; }
            set
            {
                SetValue(ref datumDo, value);
                OnPropertyChanged(nameof(datumDo));
            }
        }

        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                SetValue(ref naziv, value);
                OnPropertyChanged(nameof(naziv));
            }
        }

        private readonly bool allday = true;
        public bool AllDay => allday;

        private string opis;

        public string Opis
        {
            get { return opis; }
            set
            {
                SetValue(ref opis, value);
                OnPropertyChanged(nameof(opis));
            }
        }

        private bool vidljivo;

        public bool Vidljivo
        {
            get { return vidljivo; }
            set
            {
                SetValue(ref vidljivo, value);
                OnPropertyChanged(nameof(vidljivo));
            }
        }


        public Napomena()
        {
        }

        public Napomena(DateTime datum, DateTime datumDo, string naziv, string opis)
        {
            this.Datum = datum;
            this.DatumDo = datumDo;
            this.Naziv = naziv;
            this.Opis = opis;
        }

    }
}
