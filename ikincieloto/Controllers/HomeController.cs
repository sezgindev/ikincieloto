using ikincieloto.Models;
using ikincieloto.ViewModels;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ikincieloto.Controllers
{
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            return View(new İlanlarList
            {
                İlanlar = Database.Session.Query<İlan>().ToList()
            });
        }



        public ActionResult kullanıcı_edit(int id)
        {

            var user = Database.Session.Load<Kullanıcı>(id);

            if (user == null)
            {
                return HttpNotFound();
            }


            return View(new SignUp()
            {
                Ad = user.Ad,
                Soyad=user.Soyad,
                KullanıcıAdı=user.KullanıcıAdı,
                Eposta=user.Eposta,
                telefon=user.telefon,
                şifre=user.şifre_hash,

               
            });


        }
        [HttpPost]
        public ActionResult ilan_edit(int id, SignUp formData)
        {

            var user = Database.Session.Load<Kullanıcı>(id);
            if (user == null)
            {
                return HttpNotFound();
            }



            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            user.Ad = formData.Ad;
            user.Soyad = formData.Soyad;
            user.KullanıcıAdı = formData.KullanıcıAdı;
            user.telefon = formData.telefon;
            user.şifre_hash = formData.şifre;
            //ilan.imagepath = FileUpload.FileName(file);
            Database.Session.Update(user); //insert into Users (USername,password_hash,email) values ....
            Database.Session.Flush();
            return RedirectToAction("Index", "Home");


        }

    }
}