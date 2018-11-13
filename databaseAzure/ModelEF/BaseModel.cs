using System;
using System.Collections.Generic;
using System.Text;

namespace databaseAzure
{
    public class BaseModel
    {
        public string Kreirao { get; set; }

        public DateTime KreiraoVrijeme { get; set; }
        public string Promijenio { get; set; }

        public DateTime PromijenioVrijeme { get; set; }

        public string Napomena { get; set; }
    }
}
