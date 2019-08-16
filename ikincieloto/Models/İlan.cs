using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace ikincieloto.Models
{
 

    public class İlan
    {
        public virtual int id { get; set; }
        [Required(ErrorMessage = "Lütfen arabanın markasını giriniz")]
        public virtual string Marka { get; set; }
        [Required(ErrorMessage = "Lütfen araba modelini giriniz")]
        public virtual string Modeli  { get; set; }
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
        public virtual string imagepath { get; set; }
        public virtual string kullanıcıilanı { get; set; }
        public virtual string Açıklama { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon")]
        [Phone]
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public virtual string telefon { get; set; }

    }

    public class İlanMap : ClassMapping<İlan>
    {
        public İlanMap()
        {
            Table("İlanlar");

            Id(x => x.id, x => x.Generator(Generators.Identity));
            Property(x => x.Marka, x => x.NotNullable(true));
            Property(x => x.kullanıcıilanı, x => x.NotNullable(true));
            Property(x => x.Modeli, x => x.NotNullable(true));
            Property(x => x.Yıl, x => x.NotNullable(true));
            Property(x => x.Fiyat, x => x.NotNullable(true));
            Property(x => x.Kilometre, x => x.NotNullable(true));
            Property(x => x.Yakıt, x => x.NotNullable(true));
            Property(x => x.Renk, x => x.NotNullable(true));
            Property(x=>x.ilantarihi, x => x.NotNullable(true));
            Property(x=>x.imagepath, x => x.NotNullable(true));
            Property(x=>x.telefon, x => x.NotNullable(true));
            Property(x=>x.Eposta, x => x.NotNullable(true));
            Property(x=>x.Açıklama, x => x.NotNullable(true));

           
            Property(x => x.Vites, x => x.NotNullable(true));
         


        }
    }
   
}