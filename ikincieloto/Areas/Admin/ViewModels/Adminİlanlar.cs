using ikincieloto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ikincieloto.Areas.Admin.ViewModels
{
    public class Adminİlanlar
    {
        public IEnumerable<İlan> İlanlar { get; set; }
    }
    public class İlanEdit
    {
        
        public virtual string Marka { get; set; }
        [Required(ErrorMessage = "Lütfen araba modelini giriniz")]
        public virtual string Modeli { get; set; }
        [Required(ErrorMessage = "Lütfen yıl giriniz ")]
        public virtual string Yıl { get; set; }
        [Required(ErrorMessage = "Lütfen arabanın fiyatını belirtiniz")]
        public virtual string Fiyat { get; set; }
        [Required(ErrorMessage = "Lütfen arabanın kilometre değerini belirtiniz")]
        public virtual string Kilometre { get; set; }
        [Required(ErrorMessage = "Lütfen yakıt türü belirtiniz")]
        public virtual string Yakıt { get; set; }
        [Required(ErrorMessage = "Lütfen arabanın rengini  belirtiniz")]
        public virtual string Renk { get; set; }
        [Required(ErrorMessage = "Lütfen vites türü belirtiniz")]
        public virtual string Vites { get; set; }
        [DataType(DataType.Date)]
        public virtual DateTime ilantarihi { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public virtual string Eposta { get; set; }
     
        public virtual string Açıklama { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon")]
        [Phone]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public virtual string telefon { get; set; }


    }
}