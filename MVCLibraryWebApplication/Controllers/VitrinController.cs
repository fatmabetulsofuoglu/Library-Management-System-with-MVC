﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibraryWebApplication.Models.Entity;
using MVCLibraryWebApplication.Models.Sinif;

namespace MVCLibraryWebApplication.Controllers
{
    public class VitrinController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Vitrin

        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBL_KITAP.ToList();
            cs.Deger2 = db.TBL_HAKKIMIZDA.ToList();
            //var degerler = db.TBL_KITAP.ToList();
            return View(cs);
        }

        [HttpPost]
        public ActionResult Index(TBL_ILETISIM t)
        {
            db.TBL_ILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
    }
}