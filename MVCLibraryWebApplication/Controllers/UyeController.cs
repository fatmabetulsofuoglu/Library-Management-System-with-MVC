using MVCLibraryWebApplication.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MVCLibraryWebApplication.Controllers
{
    public class UyeController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Uye
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.TBL_UYELER.ToList();
            var degerler = db.TBL_UYELER.ToList().ToPagedList(sayfa,12);
            return View(degerler);
        }


        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            else
            {
                db.TBL_UYELER.Add(p);
                db.SaveChanges();
                return View();
            }
        }

        public ActionResult UyeSil(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBL_UYELER p)
        {
            var uye = db.TBL_UYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL= p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}