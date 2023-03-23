using KSAA.Domain.Entities.FunctionMaster;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
    public class FunctionMap : ClassMapping<Functions>
    {
        public FunctionMap()
        {
            Table("tbl_Functions");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.FunctionName, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.FunctionCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.ClientCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }
    }
}
