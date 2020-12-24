using EnvanterWeb.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterWeb.Controllers
{

    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }
        [HttpPost]
        
        public ActionResult Index(string user, string pass)
        {

            using (var context = new AppDbContext())
            {
                var kullanici = context.Kullanicilar.Where(x => x.KullaniciAdi == user).FirstOrDefault();
                if (kullanici == null)
                {
                    ModelState.AddModelError("userr", "Hatalı kullanıcı");
                    return View();
                }

                if (kullanici.Password != pass)
                {
                    ModelState.AddModelError("passs", "Hatalı şifre");
                    return View();
                }
                Session["user"] = kullanici;
                Session["userId"] = kullanici.Id;
                Session["login"] = kullanici.AdSoyad;
                Session["tipi"] = kullanici.KullaniciTipi;
                



                switch (kullanici.KullaniciTipi)
                {
                    case 1:
                        return RedirectToAction("index","personel");
                        break;
                    case 2:
                        return RedirectToAction("index","personel");
                        break;
                    case 3:
                        return RedirectToAction("index","destek");
                        break;
                    case 4:
                        return RedirectToAction("index", "admin");
                        break;
                    case 5:
                        return RedirectToAction("index","destek");
                        break;
                    default:
                        return RedirectToAction("index","home");
                        break;
                }
                return View();
            }
        }

        }
    }
