using KSAA.Domain.Entities.Master;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
	public class AdvanceMappingMap : ClassMapping<AdvanceMapping>
    {
        public AdvanceMappingMap()
        {
            Table("tbl_Advance_Mapping");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.CustomerCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.AdvanceMappingCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.GLAdvanceName, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.GLAdvanceCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Upload, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.LedgerMapping, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }

    }

}