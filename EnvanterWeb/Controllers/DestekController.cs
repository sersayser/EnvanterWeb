using EnvanterWeb.Filter;
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
    [AuthFilter]
    public class DestekController : Controller
    {
        
        // GET: Destek
        public ActionResult Index()
        {
            IEnumerable<Ariza> arizalar;
            using (var context = new AppDbContext())
            {
                arizalar = context.Arizalar.Include("Cihaz").Include("Kullanici").ToList();
            }
            return View(arizalar);
        }

        public ActionResult ArizaEkle()
        {

            return View();
        }
    }
}