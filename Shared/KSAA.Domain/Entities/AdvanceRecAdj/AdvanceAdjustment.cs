using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.AdvanceRecAdj
{
    public class AdvanceAdjustment : BaseEntity
    {
        //public virtual string? AdvanceReceivedId { get; set; }
        public virtual string? ClientCode { get; set; }
        public virtual string? EmployeeCode { get; set; }
        public virtual string? InvoiceNumber { get; set; }
        public virtual string? ReceiptNumber { get; set; }
        public virtual DateTime Dateofadjustment { get; set; }
        public virtual decimal? GSTIN { get; set; }
        public virtual decimal? POS { get; set; }
        public virtual decimal? Typeofsupply { get; set; }
        public virtual decimal? TaxableValue { get; set; }
        public virtual decimal? TotalAmendmentTaxableValue { get; set; }
        public virtual decimal? Rate { get; set; }
        public virtual decimal? CessPercentage { get; set; }
        public virtual decimal? CGST { get; set; }
        public virtual decimal? SGST { get; set; }
        public virtual decimal? IGST { get; set; }
        public virtual decimal? Cess { get; set; }
        public virtual decimal? TotalTax { get; set; }
        public virtual decimal? TotalreceiptValue { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
    }
}
