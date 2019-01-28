using System;
using System.Collections.Generic;
using System.Text;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.JSONModel
{
    public class EvidencijaPosjetiteljaJSONModel
    {
        public string ImePrezime { get; set; }
        public string Napomena { get; set; }
        public string Uloga { get; set; }
        public DateTime DatumDolaska { get; set; }
        public DateTime DatumOdlaska { get; set; }
        public OsobaDTO Zatvorenik { get; set; }


    }
}
