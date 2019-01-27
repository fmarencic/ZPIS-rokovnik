using System;
using System.Collections.Generic;
using System.Text;
using ZPISrokovnik.Utils;

namespace ZPISrokovnik.Views.MainView
{
    public class Osoba : BaseViewModel
    {
        private string naslovObiljezja;
        private string vrijednostObiljezja;
        public string NaslovObiljezja
        {
            get { return naslovObiljezja; }
            set
            {
                SetValue(ref naslovObiljezja, value);
                OnPropertyChanged(nameof(NaslovObiljezja));
            }
        }
        public string VrijednostObiljezja
        {
            get { return vrijednostObiljezja; }
            set
            {
                SetValue(ref vrijednostObiljezja, value);
                OnPropertyChanged(nameof(VrijednostObiljezja));
            }
        }
    }
}
