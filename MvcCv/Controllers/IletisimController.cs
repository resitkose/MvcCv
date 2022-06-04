using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class IletisimController : Controller
    {
        GenericRepository<TblIletisim> repo = new GenericRepository<TblIletisim>();
        // GET: Iletisim
        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }
        public ActionResult IletisimSil(int id)
        {
            TblIletisim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}