using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ikincieloto.Areas.Admin.Models
{
    public class Admin
    {
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız")]
        public virtual string KullanıcıAdi { get; set; }
        [Required(ErrorMessage = "Bu alanı boş bırakamazsınız") ]
        [DataType(DataType.Password)]
        public virtual string Şifre { get; set; }
    }
}
