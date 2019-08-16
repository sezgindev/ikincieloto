using ikincieloto.Areas.ViewModels;
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
   [Authorize(Roles = "admin")]
    public class KullanıcılarController : Controller
    {
        // GET: Admin/AdminHome
      
      

        public ActionResult Kullanıcılar()
        {

            return View(new User
            {
                Kullanıcılar = Database.Session.Query<Kullanıcı>().ToList()
            });
        }

        public ActionResult kullanıcı_sil(int id)
        {
            var ilanlar = Database.Session.Query<İlan>().ToList();

            var kullanıcı = Database.Session.Load<Kullanıcı>(id);

            foreach(var ilan in ilanlar)
            {
               if(kullanıcı.KullanıcıAdı == ilan.kullanıcıilanı)
                {
                    Database.Session.Delete(ilan);
                    Database.Session.Flush();

                }
            }

            if (kullanıcı == null)
            {
                return HttpNotFound();
            }

            Database.Session.Delete(kullanıcı);
            Database.Session.Flush();

            return RedirectToAction("Kullanıcılar");

        }

        public ActionResult kullanıcı_ekle()
        {
            return View(new UsersNew()
            {
                Roles = Database.Session.Query<Rol>().Select(rol =>
                 new RoleCheckBox()
                 {
                     Id = rol.RolId,
                     IsChecked = false,
                     Name = rol.RolAdı
                 }
               ).ToList()
            });
        }
        [HttpPost]
        public ActionResult kullanıcı_ekle(UsersNew formData)
        {
          if(Database.Session.Query<Kullanıcı>().Any(u => u.KullanıcıAdı == formData.KullanıcıAdı))
            {
                ModelState.AddModelError("Username", "Username must be unique");
            }

            if (!ModelState.IsValid)
            {
                return View(formData);
}

            var user = new Kullanıcı()
            {
                Ad = formData.Ad,
                Soyad=formData.Soyad,
                KullanıcıAdı=formData.KullanıcıAdı,
                Eposta=formData.Email,
                 telefon= formData.Telefon,
            };

            SyncRoles(formData.Roles, user.Roles);


            user.SetPassword(formData.Şifre);
            Database.Session.Save(user); //insert into Users (USername,password_hash,email) values ....
            Database.Session.Flush();
            return RedirectToAction("Kullanıcılar");
        }


        private void SyncRoles(IList<RoleCheckBox> checkBoxes, IList<Rol> roles)
        {
            var selectedRoles = new List<Rol>();

            foreach (var role in Database.Session.Query<Rol>())
            {
                var checkbox = checkBoxes.Single(c => c.Id == role.RolId);
                checkbox.Name = role.RolAdı;

                if (checkbox.IsChecked)
                {
                    selectedRoles.Add(role);
                }
            }

            foreach (var toAdd in selectedRoles.Where(t => !roles.Contains(t)))
            {
                roles.Add(toAdd);
            }

            foreach (var toRemove in roles.Where(t => !selectedRoles.Contains(t)).ToList())
            {
                roles.Remove(toRemove);
            }

        }



        public ActionResult kullanıcı_edit(int id)
        {

            var user = Database.Session.Load<Kullanıcı>(id);

            if (user == null)
            {
                return HttpNotFound();
            }


            return View(new UsersEdit()
            {
                Ad = user.Ad,
                Soyad = user.Soyad,
                telefon = user.telefon,
                Email = user.Eposta,
                KullanıcıAdı = user.KullanıcıAdı,
                Roles = Database.Session.Query<Rol>().Select(rol =>
                new RoleCheckBox()
                {
                    Id = rol.RolId,
                    IsChecked = false,
                    Name = rol.RolAdı
                }
              ).ToList()
            });


        
            

        }
        [HttpPost]
        public ActionResult kullanıcı_edit(int id, UsersEdit formData)
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
            user.telefon = formData.telefon;
            user.Eposta = formData.Email;
            user.KullanıcıAdı = formData.KullanıcıAdı;

            SyncRoles(formData.Roles, user.Roles);
            //ilan.imagepath = FileUpload.FileName(file);
            Database.Session.Update(user); //insert into Users (USername,password_hash,email) values ....
            Database.Session.Flush();

            return RedirectToAction("Kullanıcılar");


        }







    }

}
