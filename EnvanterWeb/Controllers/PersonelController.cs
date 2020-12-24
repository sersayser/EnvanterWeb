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
    public class PersonelController : Controller
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
                int _kullaniciId = Convert.ToInt32(Session["userId"].ToString());
                var KullaniciArizaListesi = context.Arizalar.Include("Cihaz").Include("Kullanici").Include("Bolum").Where(x => x.KullaniciId == _kullaniciId).ToList();
                ViewBag.kullaniciArizaListesi = KullaniciArizaListesi;
            }

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
                    Tarih = DateTime.Now,
                    KullaniciId = int.Parse((Session["userId"].ToString())),
                    Aciklama = aciklama
                };
                context.Arizalar.Add(yeniAriza);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}