using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mevzuuCafe.Models.Entity;

namespace mevzuuCafe.Controllers
{
    public class IntroController : Controller
    {
        // GET: Intor
        CafeDbEntities db = new CafeDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var intro = db.tblintro.ToList();
            return View(intro);
        }


        
        public ActionResult EditIntro(int id)
        {
            var intro = db.tblintro.Find(id);
            return View("EditIntro", intro);
        }

        public ActionResult Edit(tblintro pInt)
        {
            var tanitim = db.tblintro.Find(pInt.tanitimID);
            tanitim.baslik = pInt.baslik;
            tanitim.metin = pInt.metin;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}