using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mevzuuCafe.Models.Entity;

namespace mevzuuCafe.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        CafeDbEntities db = new CafeDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var galleries = db.tblGallery.ToList();
            return View(galleries);
        }

        [HttpGet]
        public ActionResult EditGallery(int? id)
        {
            if (id ==null)
            {
                return HttpNotFound();
            }

            var glr = db.tblGallery.Find(id);

            if (glr == null)
            {
                return HttpNotFound();
            }
            return View(glr);
        }

        [HttpPost]
        public ActionResult EditGallery(int id,tblGallery pglr)
        {
            //var resimler = db.tblGallery.Find(pglr.imgID);
            var resimler = db.tblGallery.Find(id);
            resimler.imgName = pglr.imgName;
            resimler.imgView = pglr.imgView;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}