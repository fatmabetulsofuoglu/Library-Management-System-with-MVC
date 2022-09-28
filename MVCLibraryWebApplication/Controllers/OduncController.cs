using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibraryWebApplication.Models.Entity;

namespace MVCLibraryWebApplication.Controllers
{
    public class OduncController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == false).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult OduncVer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET p)
        {
            var hareket = db.TBL_HAREKET.Find(p.ID);
            db.TBL_HAREKET.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult OduncIade(int id)
        {
            var odunc = db.TBL_HAREKET.Find(id);
            return View("OduncIade", odunc);
        }

        public ActionResult OduncGuncelle(TBL_HAREKET p)
        {
            var hareket = db.TBL_HAREKET.Find(p.ID);
            hareket.UYEIADETARIH = p.UYEIADETARIH;
            hareket.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}