using ikincieloto.Areas.Admin.ViewModels;
using ikincieloto.Models;
using ikincieloto.ViewModels;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ikincieloto.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin,editor")]
    public class İlanlarController : Controller
    {
        public ActionResult AnaSayfa()
        {

            return View(new Adminİlanlar
            {
                İlanlar = Database.Session.Query<İlan>().ToList()
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

            return RedirectToAction("AnaSayfa");

        }
    
        public ActionResult ilan_edit(int id)
        {

            var ilan = Database.Session.Load<İlan>(id);

            if (ilan == null)
            {
                return HttpNotFound();
            }


            return View(new İlanEdit()
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
                Açıklama=ilan.Açıklama,
                telefon=ilan.telefon
                
              

            });


        }
        [HttpPost]
        public ActionResult ilan_edit(int id, İlanEdit formData)
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
            ilan.ilantarihi = DateTime.Today;
            ilan.kullanıcıilanı = User.Identity.Name;
            
            Database.Session.Update(ilan);
            Database.Session.Flush();

            return RedirectToAction("AnaSayfa");


        }

    }
}