using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibraryWebApplication.Models.Entity;

namespace MVCLibraryWebApplication.Controllers
{
    public class KitapController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Kitap
        public ActionResult Index(string p)
        {
            var kitap = from k in db.TBL_KITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitap = kitap.Where(m=>m.AD.Contains(p));
            }
            return View(kitap.ToList());
        }

        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger = (from i in db.TBL_KATEGORI.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;

            List<SelectListItem> deger2 = (from i in db.TBL_YAZAR.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD +" "+ i.SOYAD,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from i in db.TBL_YAYINEVI.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.dgr3 = deger3;

            return View();  
        }

        [HttpPost] 
        public ActionResult KitapEkle(TBL_KITAP p)
        {
            var kategori = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var yazar = db.TBL_YAZAR.Where(k => k.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            var yayinevi = db.TBL_YAYINEVI.Where(k => k.ID == p.TBL_YAYINEVI.ID).FirstOrDefault();
            p.TBL_KATEGORI = kategori;
            p.TBL_YAZAR = yazar;
            p.TBL_YAYINEVI = yayinevi;

            db.TBL_KITAP.Add(p);
            db.SaveChanges(); 
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBL_KITAP.Find(id);
            db.TBL_KITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TBL_KITAP.Find(id);
            List<SelectListItem> deger = (from i in db.TBL_KATEGORI.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.AD,
                                              Value = i.ID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;

            List<SelectListItem> deger2 = (from i in db.TBL_YAZAR.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD + " " + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            List<SelectListItem> deger3 = (from i in db.TBL_YAYINEVI.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(TBL_KITAP p)
        {
            var kitap = db.TBL_KITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYILI = p.BASIMYILI;
            kitap.SAYFASAYISI = p.SAYFASAYISI;

            var kategori = db.TBL_KATEGORI.Where(k => k.ID == p.TBL_KATEGORI.ID).FirstOrDefault();
            var yazar = db.TBL_YAZAR.Where(y=> y.ID == p.TBL_YAZAR.ID).FirstOrDefault();
            var yayinevi = db.TBL_YAYINEVI.Where(y => y.ID == p.TBL_YAYINEVI.ID).FirstOrDefault();

            kitap.KATEGORI = kategori.ID;
            kitap.YAZAR = yazar.ID;
            kitap.YAYINEVI = yayinevi.ID;
            kitap.DURUM = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}