using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.AdvanceRecAdj
{
    public class AdvanceReceivedViewModule
    {
        public long Id { get; set; }
        public string? ClientCode { get; set; }
        public string? ReceiptNumber { get; set; }
        public DateTime? DateofReceipt { get; set; }
        public string? GSTIN { get; set; }
        public string? POS { get; set; }
        public string? TypeOfSupply { get; set; }
        public decimal? TaxableValue { get; set; }
        public decimal? TotalAmendmentTaxableValue { get; set; }
        public decimal? Rate { get; set; }
        public decimal? CessPercentage { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? IGST { get; set; }
        public decimal? Cess { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal TotalInvoiceValue { get; set; }
    }
}
