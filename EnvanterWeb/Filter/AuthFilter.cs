using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnvanterWeb.Models.Entity;

namespace EnvanterWeb.Filter
{
    public class AuthFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["user"] == null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
            //else
            //{
            //    switch (filterContext.HttpContext.Session["tipi"])
            //    {
            //        case 1:
            //            filterContext.Result = new RedirectResult("/Personel/Index");
            //            break;
            //        case 2:
            //            filterContext.Result = new RedirectResult("/Personel/Index");
            //            break;
            //        case 3:
            //            filterContext.Result = new RedirectResult("/Destek/Index");
            //            break;
            //        case 4:
            //            filterContext.Result = new RedirectResult("/Admin/Index");
            //            break;
            //        case 5:
            //            filterContext.Result = new RedirectResult("/Destek/Index");
            //            break;
            //        default:
            //            filterContext.Result = new RedirectResult("/Home/Index");
            //            break;

            //    }
            //}
   
        }
    }
}