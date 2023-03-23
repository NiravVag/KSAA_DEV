using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.Master
{
    public class Location : BaseEntity
    {
        public virtual string? Location_Code { get; set; }
        public virtual string? Address { get; set; }
        public virtual string? GSTRegistrationNo { get; set; }
        public virtual string? TypeOfUnit { get; set; }
        public virtual string? ProductsManufactured { get; set; }
        public virtual string? ProductsTraded { get; set; }
        public virtual string? TypeOfServicesProvided { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
    }
}
