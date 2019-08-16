using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ikincieloto.Areas.ViewModels;
using ikincieloto.Models;
using ikincieloto.Areas.Admin.Models;
using NHibernate.Linq;
namespace ikincieloto.Areas.Admin.Controllers
{
  
    public class GirisController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Admin formData, string returnUrl)
        {


            var user = Database.Session.Query<Kullanıcı>().FirstOrDefault(p => p.KullanıcıAdı == formData.KullanıcıAdi);
            if (formData.Şifre == null)
            {
                return View();
            }

            if (user == null || !user.CheckPassword(formData.Şifre))
            {
                ModelState.AddModelError("Username", "Username or password is incorrect");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }



            FormsAuthentication.SetAuthCookie(formData.KullanıcıAdi, true);


            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            return RedirectToAction("AnaSayfa", "İlanlar", new { area = "Admin" });
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}