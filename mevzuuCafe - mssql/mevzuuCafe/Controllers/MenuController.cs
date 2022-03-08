using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mevzuuCafe.Models.Entity;

namespace mevzuuCafe.Controllers
{
    public class MenuController : Controller
    {
        CafeDbEntities db = new CafeDbEntities();
        public ActionResult Index()
        {

            var menus = db.tblMenu.ToList();
            return View(menus);
        }
    }
}