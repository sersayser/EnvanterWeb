using EnvanterWeb.Filter;
using EnvanterWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterWeb.Controllers
{
    [AuthFilter]
    public class AdminController : Controller
    {

        
        public ActionResult Index()
        {
            using (var context = new AppDbContext())
            {
                var Cihazlistesi = (from x in context.Cihazlar
                                    select x).ToList() as IEnumerable<Cihaz>;
                ViewBag.Cihazlistesi = Cihazlistesi;
            }

            using (var context = new AppDbContext())
            {
                var markalistesi = (from x in context.Markalar
                                    select x).ToList() as IEnumerable<Marka>;
                ViewBag.Markalistesi = markalistesi;
            }

            using (var context = new AppDbContext())
            {
                var CihazTipiListesi = (from x in context.CihazTipleri
                                        select x).ToList() as IEnumerable<CihazTipi>;
                ViewBag.CihazTipiListesi = CihazTipiListesi;
            }

            using (var context = new AppDbContext())
            {
                var KullaniciTipiListesi = (from x in context.KullaniciTipleri
                                            select x).ToList() as IEnumerable<KullaniciTipi>;
                ViewBag.KullaniciTipiListesi = KullaniciTipiListesi;
            }

            using (var context = new AppDbContext())
            {
                var BolumListesi = (from x in context.Bolumler
                                   select x).ToList() as IEnumerable<Bolum>;
                ViewBag.BolumListesi = BolumListesi;
            }

            return View();
        }

        public ActionResult Ariza()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ariza(int Id, string aciklama)
        {
            using (var context = new AppDbContext())
            {
                var yeniAriza = new Ariza()
                {
                    CihazId = Id,
                    Tarih = DateTime.UtcNow,
                    KullaniciId = int.Parse((Session["userId"].ToString())),
                    Aciklama = aciklama
                };
                context.Arizalar.Add(yeniAriza);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CihazEkle(int bolumid, int uretimyili, int markaId, int cihaztipiId, string model, string serino)
        {
            using (var context = new AppDbContext())
            {
                var yenicihaz = new Cihaz()
                {
                    BolumId = bolumid,
                    UretimYili = uretimyili,
                    MarkaId = markaId,
                    CihazTipiId = cihaztipiId,
                    Model = model,
                    SeriNo = serino,
                    GarantiliMi = true
                };
                context.Cihazlar.Add(yenicihaz);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult KullaniciEkle(string kullaniciadi, string password, string adsoyad, int kullanicitipi, int bolumid)
        {
            using (var context = new AppDbContext())
            {
                var yenikullanici = new Kullanici()
                {
                   KullaniciAdi = kullaniciadi,
                   Password = password,
                   AdSoyad = adsoyad,
                   KullaniciTipi = kullanicitipi,
                   BolumId = bolumid,
                   AktifMi = true
                };
                context.Kullanicilar.Add(yenikullanici);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}