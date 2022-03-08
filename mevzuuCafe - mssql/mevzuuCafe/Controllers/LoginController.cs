using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using mevzuuCafe.Models.Entity;
using mevzuuCafe.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace mevzuuCafe.Controllers
{
    public class LoginController : Controller
    {
        CafeDbEntities db = new CafeDbEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(tblAdmin p)
        {

            var bilgiler = db.tblAdmin.FirstOrDefault(x => x.KullaniciAdi == p.KullaniciAdi && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                return RedirectToAction("Index", "Slider");
            }
            else
            {
                return View();
            }

        }
    
    }
}