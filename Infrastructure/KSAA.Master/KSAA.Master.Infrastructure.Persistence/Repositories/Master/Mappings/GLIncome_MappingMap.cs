using KSAA.Domain.Entities.Master;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
    public class GLIncome_MappingMap : ClassMapping<GLIncome_Mapping>
    {
        public GLIncome_MappingMap()
        {
            Table("tbl_GL_Income_Mapping");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.GLIncomeCode, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.GLIncomeDescription, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }

    }
}