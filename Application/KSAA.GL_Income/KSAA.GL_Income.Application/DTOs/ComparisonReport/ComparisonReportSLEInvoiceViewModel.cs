using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.ComparisonReport
{
    public class ComparisonReportSLEInvoiceViewModel
    {
        public long Id { get; set; }
        public string? E_Invoice_Bill_No { get; set; }
        public DateTime E_invoice_Bill_Date { get; set; }
        public string? Invoice_Number { get; set; }
        public DateTime Invoice_Date { get; set; }
        public string? Invoice_Value { get; set; }
        public decimal Taxable_Value_E_Invoice { get; set; }
        public decimal Total_Tax_E_Invoice { get; set; }
        public string? Invoice_Number_SL { get; set; }
        public DateTime Invoice_Date_SL { get; set; }
        public decimal Taxable_Value_SL { get; set; }
        public decimal Total_Tax_SL { get; set; }
        public decimal Taxable_Value_Diff_Invoice { get; set; }
        public decimal Tax_Value_Diff_Invoice { get; set; }
        public string? Remarks_E_Invoice { get; set; }
        public string? Actions_E_Invoice { get; set; }
    }
}
