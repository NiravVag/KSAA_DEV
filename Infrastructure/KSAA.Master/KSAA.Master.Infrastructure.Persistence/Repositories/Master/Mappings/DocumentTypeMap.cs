using KSAA.Domain.Entities.Master;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
    public class DocumentTypeMap : ClassMapping<DocumentType>
    {
        public DocumentTypeMap()
        {
            Table("tbl_Document_Type");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.BillType, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Document_Code, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Document_Type, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.OurSoftwareProcessing, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }

    }
}
