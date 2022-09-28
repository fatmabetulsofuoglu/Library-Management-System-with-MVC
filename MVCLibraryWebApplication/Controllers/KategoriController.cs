using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibraryWebApplication.Models.Entity;

namespace MVCLibraryWebApplication.Controllers
{
    public class KategoriController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORI.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TBL_KATEGORI p)
        {
            if (!ModelState.IsValid)
            {
                return View("KategoriEkle");
            }
            else
            {
                db.TBL_KATEGORI.Add(p);
                db.SaveChanges();
                return View();
            }
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBL_KATEGORI.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(TBL_KATEGORI p)
        {
            var kategori = db.TBL_KATEGORI.Find(p.ID);
            kategori.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}