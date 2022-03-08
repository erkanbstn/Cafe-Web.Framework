using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mevzuuCafe.Models.Entity;

namespace mevzuuCafe.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        CafeDbEntities db = new CafeDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var sliders = db.tblSlider.ToList();
            return View(sliders);
        }

        [HttpGet]
        public ActionResult EditSlider(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var sld = db.tblSlider.Find(id);

            if (sld == null)
            {
                return HttpNotFound();
            }
            return View(sld);
        }

        [HttpPost]
        public ActionResult EditSlider(int id, tblSlider psld)
        {
            //var resimler = db.tblGallery.Find(pglr.imgID);
            var sliderimg = db.tblSlider.Find(id);
            sliderimg.sliderName= psld.sliderName;
            sliderimg.sliderImage = psld.sliderImage;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}