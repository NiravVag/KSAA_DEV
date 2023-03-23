using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.AdvanceRecAdj
{
    public class AdvanceAmendmentListModel
    {
        public List<AdvanceAmendmentListModel> AdvanceAmendmentList { get; set; }
        public virtual long AdvanceReceivedId { get; set; }
        public virtual string? ClientCode { get; set; }
        public virtual string? InvoiceNumber { get; set; }
        public virtual string? ReceiptNumber { get; set; }
        public virtual string? GSTIN { get; set; }
        public virtual decimal? TaxableValue { get; set; }
        public virtual decimal? Rate { get; set; }
        public virtual decimal? CessPercentage { get; set; }
        public virtual decimal? CGST { get; set; }
        public virtual decimal? SGST { get; set; }
        public virtual decimal? IGST { get; set; }
        public virtual decimal? Cess { get; set; }
        public virtual decimal? TotalTax { get; set; }
        public virtual decimal TotalInvoiceValue { get; set; }
    }
}
