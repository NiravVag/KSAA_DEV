using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.ClientRegister
{
    public class ClientBankAccount : BaseEntity
    {
        public virtual string? BranchName { get; set; }
        public virtual string? AccountNo { get; set; }
        public virtual string? Type { get; set; }
        public virtual string? IFSCCode { get; set; }
        public virtual string? BankPassbookPage { get; set; }
        public virtual string? StatementCancelledCheque { get; set; }
        public virtual string? CustomerCode { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
    }
}
