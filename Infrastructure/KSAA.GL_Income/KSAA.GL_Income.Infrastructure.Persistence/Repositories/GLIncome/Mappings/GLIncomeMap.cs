using KSAA.Domain.Entities.GL_Income;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Infrastructure.Persistence.Repositories.GLIncome.Mappings
{
    public class GLIncomeMap : ClassMapping<GL_IncomeData>
    {
        public GLIncomeMap()
        {
            //Table("tbl_GL_Income");
            //Lazy(true);
            //Id(x => x.Id);
            //Property(x => x.Company_Code, map => { map.NotNullable(true); map.Length(50); });
            //Property(x => x.Company_Name, map => { map.NotNullable(true); map.Length(50); });
            //Property(x => x.Company_Address, map => { map.NotNullable(true); map.Length(50); });
            //Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            //Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            //Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }
    }
}
