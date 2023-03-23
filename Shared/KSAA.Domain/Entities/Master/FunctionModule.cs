using KSAA.Domain.Common;
using KSAA.Domain.Entities.FunctionMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.Master
{
    public class FunctionModule : BaseEntity
    {
        public virtual long FunctionId { get; set; }
        public virtual string? ModuleName { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
        public virtual Functions Function { get; set; }
    }
}
