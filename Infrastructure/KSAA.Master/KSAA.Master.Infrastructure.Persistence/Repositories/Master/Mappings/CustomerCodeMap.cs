using KSAA.Domain.Entities.Master;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
    public class CustomerCodeMap : ClassMapping<CustomerCode>
    {
        public CustomerCodeMap()
        {
            Table("tbl_Customer_Code");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.Customer_Code, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.GSTN, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Name, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Location, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Address, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }
    }
}