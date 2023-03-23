using KSAA.Domain.Entities.Master;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
    public class TaxCodeMap : ClassMapping<TaxCode>
    {
        public TaxCodeMap()
        {
            Table("tbl_Tax_Code");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.Tax_Code, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.SubtaxName, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.TaxRate, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Type, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }

    }
}