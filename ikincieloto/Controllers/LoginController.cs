using ikincieloto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using ikincieloto.ViewModels;
using System.Web.Security;

namespace ikincieloto.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UserLogin formData, string returnUrl)
        {


            var user = Database.Session.Query<Kullanıcı>().FirstOrDefault(p => p.KullanıcıAdı == formData.KullanıcıAdı);
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



            FormsAuthentication.SetAuthCookie(formData.KullanıcıAdı, true);


            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }



         public ActionResult Logout()
        {
            FormsAuthentication.SignOut ();
            return RedirectToAction("Index", "Home");
        }


        public ActionResult SignUp()
        {

            return View();
        }




        [HttpPost]
        public ActionResult SignUp(SignUp model)
        {

            if (ModelState.IsValid)
            {
                var kullanıcılar = Database.Session.Query<Kullanıcı>().ToList();
                foreach (var username in kullanıcılar)
                {
                    if (username.KullanıcıAdı == model.KullanıcıAdı)
                    {
                        ModelState.AddModelError("EmailExist", "Email already exist");
                        return View();

                    }
                }

                //Eğer Tüm Parametreler doğruysa buraya gir.
                // KullanıcıMap a = new KullanıcıMap();
                var kullanıcı = new Kullanıcı
                {
                    Ad = model.Ad,
                    Soyad = model.Soyad,
                    Eposta = model.Eposta,
                    şifre_hash = model.şifre,
                    telefon=model.telefon,
                    KullanıcıAdı = model.KullanıcıAdı,
                   
                   

                };
                kullanıcı.SetPassword(model.şifre);
                Database.Session.Save(kullanıcı);

                return RedirectToAction("Login");
            }
           
            return View();
        }


     



    }
}