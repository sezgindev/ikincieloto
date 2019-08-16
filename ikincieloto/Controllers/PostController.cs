using ikincieloto.Models;
using ikincieloto.ViewModels;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ikincieloto.Controllers
{
    public class PostController : Controller
    {

        [Authorize]
        public ActionResult ilanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ilanEkle(İlan model, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {


                //Eğer Tüm Parametreler doğruysa buraya gir.
                // KullanıcıMap a = new KullanıcıMap();
                var ilanlar = new İlan
                {

                    Marka = model.Marka,
                    Modeli = model.Modeli,
                    Yıl = model.Yıl,
                    Fiyat = model.Fiyat,
                    Kilometre = model.Kilometre,
                    Yakıt = model.Yakıt,
                    telefon = model.telefon,
                    Eposta = model.Eposta,
                    Renk = model.Renk,
                    Vites = model.Vites,
                    Açıklama=model.Açıklama,
                    ilantarihi = DateTime.Today,
                    kullanıcıilanı = User.Identity.Name,



                };
                ilanlar.imagepath = FileUpload.FileName(file);


                Database.Session.Save(ilanlar);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        public ActionResult Detayli_İlan(int id)
        {
            var ilan = Database.Session.Load<İlan>(id);
          
            ViewData["deneme"] = ilan;
           

            return View();
        }


        public ActionResult ilanlarım()
        {

            return View(new İlanlarList
            {
                İlanlar = Database.Session.Query<İlan>().ToList(),
              
            });

        }
        public ActionResult ilan_sil(int id)
        {
            var ilan = Database.Session.Load<İlan>(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }

            Database.Session.Delete(ilan);
            Database.Session.Flush();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ilan_edit(int id)
        {

            var ilan = Database.Session.Load<İlan>(id);

            if (ilan == null)
            {
                return HttpNotFound();
            }


            return View(new İlanlarList()
            {
                Marka = ilan.Marka,
                Modeli = ilan.Modeli,
                Yıl = ilan.Yıl,
                Fiyat = ilan.Fiyat,
                Kilometre = ilan.Kilometre,
                Renk = ilan.Renk,
                Yakıt = ilan.Yakıt,
                Vites = ilan.Vites,
                Eposta = ilan.Eposta,
                telefon = ilan.telefon,
                açıklama = ilan.Açıklama,
                ilantarihi = DateTime.Today,
               
        });


        }
        [HttpPost]
        public ActionResult ilan_edit(int id, İlanlarList formData, HttpPostedFileBase file)
        {

            var ilan = Database.Session.Load<İlan>(id);
            if (ilan == null)
            {
                return HttpNotFound();
            }


          
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            ilan.Marka = formData.Marka;
            ilan.Modeli = formData.Modeli;
            ilan.Yıl = formData.Yıl;
            ilan.Fiyat = formData.Fiyat;
            ilan.Kilometre = formData.Kilometre;
            ilan.Yakıt = formData.Yakıt;
            ilan.Renk = formData.Renk;
            ilan.Vites = formData.Vites;
            ilan.telefon = formData.telefon;
            ilan.Eposta = formData.Eposta;
            ilan.Açıklama = formData.açıklama;
            ilan.ilantarihi = DateTime.Today;
            ilan.kullanıcıilanı = User.Identity.Name;
            //ilan.imagepath = FileUpload.FileName(file);
            Database.Session.Update(ilan); //insert into Users (USername,password_hash,email) values ....
            Database.Session.Flush();
            return RedirectToAction("Index","Home");


        }


    }
}