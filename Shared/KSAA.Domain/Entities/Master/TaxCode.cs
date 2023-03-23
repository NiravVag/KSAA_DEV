using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.Master
{
    public class TaxCode : BaseEntity
    {
        public virtual string? Tax_Code { get; set; }
        public virtual string? SubtaxName { get; set; }
        public virtual int TaxRate { get; set; }
        public virtual string? Type { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
    }
}

