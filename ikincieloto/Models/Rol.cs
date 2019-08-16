using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ikincieloto.Models
{
    public class Rol
    {
        public virtual int RolId { get; set; }
        public virtual string RolAdı { get; set; }

    }
    public class RolMap : ClassMapping<Rol>
    {
        public RolMap()
        {
            Table("Roller");

            Id(x => x.RolId, x => x.Generator(Generators.Identity));
            Property(x => x.RolAdı, x => x.NotNullable(true));
        }
    }

}