using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.Master
{
    public class TBTagging : BaseEntity
    {
        public virtual string? TBTaggingCode { get; set; }
        public virtual string? GLCode { get; set; }
        public virtual string? GLName { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual string? TagCode { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
    }
}
