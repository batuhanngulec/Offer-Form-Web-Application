using Deneme1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace Deneme1.Controllers
{
    public class FormController : Controller
    {
        public ActionResult Index(string id)
        {
            
            IDapperContext dd = new DapperContext(System.Configuration.ConfigurationManager.ConnectionStrings["DapperConn"].ConnectionString);


            IDapperTools dtp = new DapperTools(dd);
            var teklifler = dtp.Query<Teklifler>("SELECT  dbo.Sat_Teklif.Teklif_Id, dbo.Sat_Teklif.Teklif_No, dbo.Sat_Teklif.Teklif_Tarih, " +
                "dbo.Sat_Teklif.Teklif_Satici, dbo.Sat_Teklif.Teklif_Talep_Id, dbo.Sat_Teklif.Teklif_Stokkodu, Stok_Master.Master_Ad as Stok_Adi, " +
                "Stok_Kodlar.Kodlar_Kod Birim, convert(varchar,convert(decimal(12,2),dbo.Sat_Teklif.Teklif_Miktar)) as Teklif_Miktar, " +
                "dbo.Sat_Teklif.Teklif_Marka, dbo.Sat_Teklif.Teklif_Birimfiyat, dbo.Sat_Teklif.Teklif_VadeGun, " +
                "dbo.Sat_Talep.Talep_Kullanim FROM dbo.Sat_Teklif " +
                "LEFT JOIN Sat_Talep On Talep_Id = Teklif_Talep_Id " +
                "LEFT JOIN dbo.Stok_Master ON dbo.Sat_Teklif.Teklif_Stokkodu = dbo.Stok_Master.Master_GenelKod " +
                "LEFT JOIN dbo.Stok_Kodlar ON dbo.Stok_Master.Master_Altbirim = dbo.Stok_Kodlar.Kodlar_Kod " +
                "AND dbo.Stok_Kodlar.Kodlar_Sinif = '06' WHERE Teklif_WebID= @ID", new { @ID = id }).ToList();

            var kontrol = teklifler.Where(x => x.Teklif_Birimfiyat > 0).Any();
            if (kontrol == true)
            {
                return RedirectToAction("Hata", "Form");
            }

            var saticiUnvan = dtp.Query<string>("select ISNULL(Plan_Resmiad,Plan_ad) from Muh_Plan where Plan_kod=(Select top 1 Teklif_Satici from Sat_Teklif " +
                "where Teklif_WebID=@webID)", new { @webID = id }).FirstOrDefault();
            ViewBag.Satici = saticiUnvan;
            var musteriler = dtp.Query<MusteriInfo>("select Sirket_Id,Sirket_Resmiad, Sirket_Adres1, Sirket_Adres2,Sirket_Adres3, Sirket_Adresilce, " +
                "Sirket_Adresil,Sirket_Vergidaire,Sirket_Vergino,Sirket_Tel,Sirket_Sat_Fax from Muh_Sirket  WHERE Sirket_Id= @ID", new { @ID = 1 }).ToList();

            var tupleModel = new Tuple<List<Teklifler>, List<MusteriInfo>>(teklifler, musteriler);
            return View(tupleModel);
        }
        [HttpPost]
        public ActionResult Index([Bind(Prefix = "Item1")] List<Teklifler> teklifler)
        {
            #region Dapper
            IDapperContext dd = new DapperContext(System.Configuration.ConfigurationManager.ConnectionStrings["DapperConn"].ConnectionString);
            IDapperTools dtp = new DapperTools(dd);
            #endregion

            foreach (var teklif in teklifler)
            {
                
                dtp.Query("UPDATE Sat_Teklif SET Teklif_Marka= @marka, Teklif_Birimfiyat= @birim, " +
                    "Teklif_VadeGun=@vade WHERE Teklif_Id = @tid ",
                    new { @marka = teklif.Teklif_Marka ,@birim = teklif.Teklif_Birimfiyat , @vade = teklif.Teklif_VadeGun, @tid = teklif.Teklif_Id});  
               
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Hata()
        {
            return View();
        }
        
    }
}