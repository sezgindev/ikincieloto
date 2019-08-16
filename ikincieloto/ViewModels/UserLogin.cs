using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ikincieloto.ViewModels
{
    public class UserLogin
    {

        [Required(ErrorMessage = "KullanıcıAdı alanı için bilgi giriniz")]
        public string KullanıcıAdı { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Şifre { get; set; }

    }
    public class SignUp
    {

        public  int id { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon")]
        [Phone]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public string telefon { get; set; }

        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public  string Ad { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public  string Soyad { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public  string KullanıcıAdı { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public  string Eposta { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        [StringLength(12, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public  string şifre { get; set; }
        public  string roles { get; set; }

    }
    public class UsersResetPassword
    {

        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}