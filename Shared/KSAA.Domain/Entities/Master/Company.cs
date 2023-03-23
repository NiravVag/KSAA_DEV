using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.Master
{
    public class Company : BaseEntity
    {
        public string? Company_Name { get; set; }
        public string? Company_Code { get; set; }
        public string? Company_Address { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
    }
}
