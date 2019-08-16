using ikincieloto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ikincieloto.Areas.ViewModels
{
    public class Login
    {
        [Required, MaxLength(128)]
        public string KullanıcıAdı { get; set; }

        [Required, MaxLength(128)]
        public string Sifre { get; set; }
    }

    public class User
    {
        public IEnumerable<Kullanıcı> Kullanıcılar { get; set; }
    }
    public class UsersNew
    {
        public IList<RoleCheckBox> Roles { get; set; }

        [Required, MaxLength(128)]
        public string Ad { get; set; }

        [Required, MaxLength(128)]
        public string Soyad { get; set; }

        [Required, MaxLength(128)]
        public string KullanıcıAdı { get; set; }

        [Required, DataType(DataType.Password)]
        public string Şifre { get; set; }

        [Required, DataType(DataType.EmailAddress), MaxLength(256)]
        public string Email { get; set; }
         [Required, DataType(DataType.PhoneNumber), MaxLength(11)]
        public string Telefon { get; set; }
    }

    public class UsersEdit
    {
        public IList<RoleCheckBox> Roles { get; set; }

        [Required, MaxLength(128)]
        public string Ad { get; set; }

        [Required, MaxLength(128)]
        public string Soyad { get; set; }

        [Required, MaxLength(128)]
        public string KullanıcıAdı { get; set; }



        [Required, DataType(DataType.EmailAddress), MaxLength(256)]
        public string Email { get; set; }
        
        public string telefon { get; set; }
    }

    public class RoleCheckBox
    {
        public int Id { get; set; }
        public bool IsChecked { get; set; }
        public string Name { get; set; }
    }


}