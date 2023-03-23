using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.Master
{
    public class CustomerCode : BaseEntity
    {
        public virtual string? Customer_Code { get; set; }
        public virtual string? GSTN { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Location { get; set; }
        public virtual string? Address { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }

    }

}