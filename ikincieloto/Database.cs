using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using ikincieloto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ikincieloto
{
    public static class Database
    {
        private const string SessionKey = "ikincieloto.Database.SessionKey";
        private static ISessionFactory _sessionFactory;

        public static ISession Session
        {
            get
            {
                return (ISession)HttpContext.Current.Items[SessionKey];
            }
        }


        public static void Configure()
        {
           
            var config = new Configuration();
            config.Configure();

           
            var mapper = new ModelMapper();
            mapper.AddMapping<KullanıcıMap>();
            mapper.AddMapping<İlanMap>();
            mapper.AddMapping<RolMap>();
          
           

            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

       
            _sessionFactory = config.BuildSessionFactory();

        }

        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {

            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
            {
                session.Close();
            }

            HttpContext.Current.Items.Remove("Session");

        }
    }
}