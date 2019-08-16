using ikincieloto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ikincieloto.ViewModels
{
    public class İlanlarList
    {

        public IEnumerable<İlan> İlanlar { get; set; }
        public IEnumerable<Kullanıcı> Kullanıcılar { get; set; }

       
        public virtual string Eposta { get; set; }
        
       
        public virtual string telefon { get; set; }
        public virtual string Marka { get; set; }
        
        public virtual string Modeli { get; set; }
   
        public virtual string Yıl { get; set; }
      
        public virtual string Fiyat { get; set; }
      
        public virtual string Kilometre { get; set; }
       
        public virtual string Yakıt { get; set; }
      
        public virtual string Renk { get; set; }
       
        public virtual string Vites { get; set; }
        
        public virtual string açıklama { get; set; }
        public virtual DateTime ilantarihi { get; set; }

        public virtual string imagepath { get; set; }

    }
    

}