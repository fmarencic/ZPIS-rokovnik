using System;
using System.Collections.Generic;
using System.Text;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.JSONModel
{
    public class EvidencijaSudskogNadzoraJSONModel
    {
        public OsobaDTO Sud { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan Od { get; set; }
        public TimeSpan Do { get; set; }
    }
}
