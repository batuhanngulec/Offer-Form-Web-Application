using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Deneme1.Models
{
    public class Teklifler
    {
        public int Teklif_Id { get; set; }
        public string Stok_Adi { get; set; }
        public string Teklif_Stokkodu { get; set; }
        public string Birim { get; set; }
        public decimal Teklif_Miktar { get; set; }
        public string Teklif_Marka { get; set; }
        public decimal Teklif_Birimfiyat { get; set; }
        public int Teklif_VadeGun { get; set; }
        public Guid Teklif_WebID { get; set; }
        public DateTime Teklif_Tarih { get; set; }

        // ekstra
        //public string Plan_Resmiad { get; set; }
        //public string Plan_ad { get; set; }

        //public int Plan_Kod { get; set; }

        //public string Teklif_Satici { get; set; }

    }
}