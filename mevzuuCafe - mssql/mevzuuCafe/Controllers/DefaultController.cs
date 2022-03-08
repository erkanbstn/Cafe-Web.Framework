using mevzuuCafe.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mevzuuCafe.Controllers
{
    public class DefaultController : Controller
    {
        CafeDbEntities db = new CafeDbEntities();
        // GET: Default
        public ActionResult Index()
        {
            var experience = db.tblintro.ToList();
            var about = db.tblHome.Where(x => x.homeID == 2).FirstOrDefault();
            return View();
            //return View();
        }

       
        public PartialViewResult About()
        {
            var about = db.tblHome.Where(x => x.homeID == 1).FirstOrDefault();
            return PartialView(about);
        }

        public PartialViewResult Images()
        {
            var image = db.tblGallery.ToList();
            return PartialView(image);
        }

        public PartialViewResult Experience()
        {
            var experience = db.tblintro.ToList();
            return PartialView(experience);
        }

        public PartialViewResult Saying()
        {
            var about = db.tblHome.Where(x => x.homeID == 2).FirstOrDefault();
            return PartialView(about);
        }
    }
}