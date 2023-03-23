using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.AdvanceRecAdj
{
    [Table("tbl_Advance_Received_Module")]
    public class AdvanceReceived : BaseEntity
    {
        public virtual string? ClientCode { get; set; }
        public virtual string? ReceiptNumber { get; set; }
        public virtual DateTime? DateofReceipt { get; set; }
        public virtual string? GSTIN { get; set; }
        public virtual string? POS { get; set; }
        public virtual string? TypeOfSupply { get; set; }
        public virtual decimal? TaxableValue { get; set; }
        public virtual decimal? TotalAmendmentTaxableValue { get; set; }
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
    }
}
