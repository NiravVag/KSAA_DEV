using KSAA.Domain.Entities.Master;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
	public class GSTOutputLiabilityCodesMap : ClassMapping<GSTOutputLiabilityCodes>
    {
        public GSTOutputLiabilityCodesMap()
        {
            Table("tbl_GST_Output_Liability_Codes");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.CustomerCode, map => { map.NotNullable(true); map.Length(30); });
            Property(x => x.GLLiabilityName, map => { map.NotNullable(true); map.Length(100); });
            Property(x => x.GLLiabilityCode, map => { map.NotNullable(true); map.Length(30); });
            Property(x => x.Upload, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.LedgerMapping, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }
    }
}