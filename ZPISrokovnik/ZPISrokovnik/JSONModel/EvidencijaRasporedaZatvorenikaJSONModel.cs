using System;
using System.Collections.Generic;
using System.Text;
using ZpisRokovnikService.DataLayer;

namespace ZPISrokovnik.JSONModel
{
    public class EvidencijaRasporedaZatvorenikaJSONModel
    {
        public string Zatvorenik { get; set; }
        public DomenaDTO RadnoMjesto { get; set; }
        public DateTime? DatumRadOd { get; set; }
        public DateTime? DatumRadDo { get; set; }
        public DateTime? DatumRasporeda { get; set; }
    }
}
