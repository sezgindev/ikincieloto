using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using ikincieloto.Models;

namespace ikincieloto.Infrastructure
{
    public static class Auth
    {
        private const string UserKey = "ikincieloto.Auth.UserKey";
        public static Kullanıcı User
        {
            get
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return null;
                }

                var user = HttpContext.Current.Items[UserKey] as Kullanıcı;

                if (user == null)
                {
                    user = Database.Session.Query<Kullanıcı>().FirstOrDefault(p => p.KullanıcıAdı == HttpContext.Current.User.Identity.Name);
                }

                if (user == null)
                    return null;

                HttpContext.Current.Items[UserKey] = user;

                return user;
            }



        }
    }
}