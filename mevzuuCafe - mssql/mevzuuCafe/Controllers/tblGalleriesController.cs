using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mevzuuCafe.Models.Entity;

namespace mevzuuCafe.Controllers
{
    public class tblGalleriesController : Controller
    {
        private CafeDbEntities db = new CafeDbEntities();

        public ActionResult Index()
        {
            return View(db.tblGallery.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGallery tblGallery = db.tblGallery.Find(id);
            if (tblGallery == null)
            {
                return HttpNotFound();
            }
            return View(tblGallery);
        }

        public ActionResult Create()
        {
            return View();
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "imgID,imgName,imgView")] tblGallery tblgallery, HttpPostedFileBase ImageView)
        {
            if (ModelState.IsValid)
            {
                if(ImageView.ContentLength > 0)
                {
                    var image = Path.GetFileName(ImageView.FileName);
                    var path = Path.Combine(Server.MapPath("~/style_media/gallery"), image);
                    ImageView.SaveAs(path);

                    tblgallery.imgView = "~/style_media/gallery/" + image;
                    db.tblGallery.Add(tblgallery);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return HttpNotFound();
            }

            return HttpNotFound();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGallery tblGallery = db.tblGallery.Find(id);
            if (tblGallery == null)
            {
                return HttpNotFound();
            }
            return View(tblGallery);
        }

         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "imgID,imgName,imgView")] tblGallery tblGallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblGallery);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGallery tblGallery = db.tblGallery.Find(id);
            if (tblGallery == null)
            {
                return HttpNotFound();
            }
            return View(tblGallery);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGallery tblGallery = db.tblGallery.Find(id);
            db.tblGallery.Remove(tblGallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
