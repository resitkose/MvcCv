using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        // GET: Egitim
        public ActionResult Index()
        {
            var egitim = repo.List();
            return View(egitim);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TblEgitimlerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            TblEgitimlerim t = repo.Find(x => x.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik1 = p.AltBaslik1;
            t.AltBaslik2 = p.AltBaslik2;
            t.Tarih = p.Tarih;
            t.GNO = p.GNO;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}