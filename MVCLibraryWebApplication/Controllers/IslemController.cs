using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCLibraryWebApplication.Models.Entity;

namespace MVCLibraryWebApplication.Controllers
{
    public class IslemController : Controller
    {
        DBKUTUPHANEEntities db= new DBKUTUPHANEEntities();  

        // GET: Islem
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}