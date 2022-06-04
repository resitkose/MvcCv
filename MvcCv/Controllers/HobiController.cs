﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;


namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        // GET: Hobi
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobiEkle(TblHobilerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            TblHobilerim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        public ActionResult HobiGetir(int id)
        {
            TblHobilerim t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult HobiGetir(TblHobilerim p)
        {
            TblHobilerim t = repo.Find(x => x.ID == p.ID);
            t.Aciklama1 = p.Aciklama1;
            t.Aciklama2 = p.Aciklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }

    }
}