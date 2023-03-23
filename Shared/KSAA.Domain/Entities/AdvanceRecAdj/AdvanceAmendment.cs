using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.AdvanceRecAdj
{
    [Table("tbl_Advance_Received_Module_Amendment")]
    public class AdvanceAmendment : BaseEntity
    {
        public virtual long AdvanceReceivedId { get; set; }
        public virtual string? ClientCode { get; set; }
        public virtual string? InvoiceNumber { get; set; }
        public virtual string? ReceiptNumber { get; set; }
        //public virtual string? GSTIN { get; set; }
        public virtual decimal? TaxableValue { get; set; }
        public virtual decimal? Rate { get; set; }
        public virtual decimal? CessPercentage { get; set; }
        public virtual decimal? CGST { get; set; }
        public virtual decimal? SGST { get; set; }
        public virtual decimal? IGST { get; set; }
        public virtual decimal? Cess { get; set; }
        public virtual decimal? TotalTax { get; set; }
        public virtual decimal TotalInvoiceValue { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
    }
}
