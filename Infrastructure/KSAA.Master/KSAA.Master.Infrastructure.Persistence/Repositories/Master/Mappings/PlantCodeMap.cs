using KSAA.Domain.Entities.Master;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Infrastructure.Persistence.Repositories.Master.Mappings
{
    public class PlantCodeMap : ClassMapping<PlantCode>
    {
        public PlantCodeMap()
        {
            Table("tbl_Plant_Code");
            Lazy(true);
            Id(x => x.Id);
            Property(x => x.Address, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.Plant_Code, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.GSTRegistrationNo, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.TypeOfUnit, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.ProductsManufactured, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.ProductsTraded, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.ServicesProvided, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.RegistrationType, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IP, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.BrowserCase, map => { map.NotNullable(true); map.Length(50); });
            Property(x => x.IsActive, map => { map.NotNullable(true); map.Length(50); });
        }

    }
}