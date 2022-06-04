using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin t)
        {
            var userinfo = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == t.KullaniciAdi && x.Sifre == t.Sifre);
            if(userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.KullaniciAdi,false);
                Session["KullaniciAdi"] = userinfo.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Hakkimda");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}