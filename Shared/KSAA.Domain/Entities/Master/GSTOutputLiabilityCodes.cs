using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.Master
{
	public class GSTOutputLiabilityCodes : BaseEntity
    {
        public virtual string? CustomerCode { get; set; }
        public virtual string? GLLiabilityName { get; set; }
        public virtual string? GLLiabilityCode { get; set; }
        public virtual string? Upload { get; set; }
        public virtual string? LedgerMapping { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
    }
}