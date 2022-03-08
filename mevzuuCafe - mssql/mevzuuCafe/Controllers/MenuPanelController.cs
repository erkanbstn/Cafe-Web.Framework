using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mevzuuCafe.Models.Entity;

namespace mevzuuCafe.Controllers
{
    public class MenuPanelController : Controller
    {
        // GET: MenuPanel
        CafeDbEntities db = new CafeDbEntities();
        [Authorize]
        public ActionResult Index()
        {
            var menus = db.tblMenu.ToList();
            return View(menus);
        }

        public ActionResult MenuReport()
        {
            var menus = db.tblMenu.ToList();
            return View(menus);
        }

        [HttpGet]
        public ActionResult EditMenu(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var mn = db.tblMenu.Find(id);

            if (mn == null)
            {
                return HttpNotFound();
            }
            return View(mn);
        }

        [HttpPost]
        public ActionResult EditMenu(int id, tblMenu pmn)
        {
            //var resimler = db.tblGallery.Find(pglr.imgID);
            var menuler = db.tblMenu.Find(id);
            menuler.menuName = pmn.menuName;
            menuler.menuContent = pmn.menuContent;
            menuler.menuImage = pmn.menuImage;
            menuler.menuPrice = pmn.menuPrice;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}