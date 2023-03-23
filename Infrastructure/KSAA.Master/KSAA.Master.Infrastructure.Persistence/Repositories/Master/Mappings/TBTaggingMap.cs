using KSAA.Domain.Entities.Master;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
    public class TBTaggingMap : ClassMapping<TBTagging>
    {
        public TBTaggingMap()
        {
            Table("tbl_TBTagging");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.TBTaggingCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.GLCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.GLName, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Amount, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.TagCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }
    }
}
