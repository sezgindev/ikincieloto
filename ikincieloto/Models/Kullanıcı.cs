using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;


namespace ikincieloto.Models
{
    public class Kullanıcı
    {
     
        public virtual int id { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public virtual string Ad { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public virtual string Soyad { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public virtual string KullanıcıAdı { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public virtual string telefon { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]

        public virtual string Eposta { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        [DataType(DataType.Password)]
        public virtual string şifre_hash { get; set; }
        public virtual IList<Rol> Roles { get; set; }
        public Kullanıcı()
        {
            İlanlar = new List<İlan>();
            Roles = new List<Rol>();
        }
        public virtual IList<İlan> İlanlar { get; set; }


        public virtual void SetPassword(string password)
        {
            şifre_hash = BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, şifre_hash);
        }
    }

    public class  KullanıcıMap : ClassMapping<Kullanıcı>
    {
        public KullanıcıMap()
        {
            Table("kullanıcı");

            Id(x => x.id, x => x.Generator(Generators.Identity));
            Property(x => x.Ad, x => x.NotNullable(true));
            Property(x => x.Soyad, x => x.NotNullable(true));
            Property(x => x.KullanıcıAdı, x => x.NotNullable(true));
            Property(x => x.telefon, x => x.NotNullable(true));
            Property(x => x.Eposta, x => x.NotNullable(true));         
            Property(x => x.şifre_hash, x => {
                x.NotNullable(true);
                x.Column("şifre_hash");
            });
            Bag(x => x.Roles, x => {
                x.Table("Kullanıcı_Rolleri");
                x.Key(k => k.Column("KullancıId"));
            }, x => x.ManyToMany(k => k.Column("RolId")));

        }

    }
    }

