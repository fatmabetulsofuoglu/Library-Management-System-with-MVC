using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibraryWebApplication.Models.Entity;

namespace MVCLibraryWebApplication.Controllers
{
    public class PersonelController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Personel
        public ActionResult Index(string p)
        {
            var personel = from k in db.TBL_PERSONEL select k;
            if (!string.IsNullOrEmpty(p))
            {
                personel = personel.Where(m => m.AD.Contains(p));
            }
            return View(personel.ToList());
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TBL_PERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            else
            {
                db.TBL_PERSONEL.Add(p);
                db.SaveChanges();
                return View();
            }
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TBL_PERSONEL.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(TBL_PERSONEL p)
        {
            var personel = db.TBL_PERSONEL.Find(p.ID);
            personel.AD = p.AD;
            personel.SOYAD = p.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBL_PERSONEL.Find(id);
            db.TBL_PERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}