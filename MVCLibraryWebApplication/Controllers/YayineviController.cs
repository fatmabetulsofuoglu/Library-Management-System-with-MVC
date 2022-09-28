using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibraryWebApplication.Models.Entity;

namespace MVCLibraryWebApplication.Controllers
{
    public class YayineviController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities(); 
        // GET: Yayinevi
        public ActionResult Index()
        {
            var degerler = db.TBL_YAYINEVI.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YayineviEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YayineviEkle(TBL_YAYINEVI p)
        {
            if (!ModelState.IsValid)
            {
                return View("YayineviEkle");
            }
            else
            {
                db.TBL_YAYINEVI.Add(p);
                db.SaveChanges();
                return View();
            }
        }

        public ActionResult YayineviSil(int id)
        {
            var yayinevi = db.TBL_YAYINEVI.Find(id);
            db.TBL_YAYINEVI.Remove(yayinevi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YayineviGetir(int id)
        {
            var yayinevi = db.TBL_YAYINEVI.Find(id);
            return View("YayineviGetir", yayinevi);
        }

        public ActionResult YayineviGuncelle(TBL_YAYINEVI p)
        {
            var yayinevi = db.TBL_YAYINEVI.Find(p.ID);
            yayinevi.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}