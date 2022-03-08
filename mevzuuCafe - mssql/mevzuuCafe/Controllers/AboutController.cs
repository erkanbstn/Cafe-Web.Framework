using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mevzuuCafe.Models.Entity;

namespace mevzuuCafe.Controllers
{
    public class AboutController : Controller
    {

        // GET: About
        CafeDbEntities db = new CafeDbEntities();

        [Authorize]
        public ActionResult Index()
        {
            var homedb = db.tblHome.ToList();
            return View(homedb);
        }

        public ActionResult EditAbout(int id)
        {
            var hm = db.tblHome.Find(id);
            return View("EditAbout", hm);
        }

        public ActionResult Edit(tblHome phm)
        {
            var aboutdata = db.tblHome.Find(phm.homeID);
            aboutdata.bolum = phm.bolum;

            aboutdata.resim = phm.resim;

            aboutdata.metin = phm.metin;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}