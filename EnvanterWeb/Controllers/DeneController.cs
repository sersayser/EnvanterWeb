
using EnvanterWeb.Models;
using EnvanterWeb.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EnvanterWeb.Controllers
{
    public class DeneController : Controller
    {
        // GET: Dene
        public ActionResult Index()
        {
            using (var context = new AppDbContext())
            {
                var Cihazlistesi = (from x in context.Cihazlar
                                    
                                    select x).ToList() as IEnumerable<Cihaz>;
                ViewBag.Cihazlistesi = Cihazlistesi;
            }

                return View();
        }

        
        public ActionResult Ariza()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Arizax(int Id, string aciklama)
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
    }
}