using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.ComparisonReport
{
    public class CompairsonReportsSLEInvoiceEWay
    {
        public List<CompairsonReportsSLEInvoiceEWay> ComparSLInvoiceList { get; set; }
        public long Comparison_Report_E_Invoice_Portal_ID { get; set; }
        public string E_Invoice_Bill_No { get; set; }
        public DateTime E_invoice_Bill_Date { get; set; }
        public string Invoice_Number { get; set; }
        public DateTime Invoice_Date { get; set; }
        public string Invoice_Value { get; set; }
        public decimal Taxable_Value_E_Invoice { get; set; }
        public decimal Total_Tax_E_Invoice { get; set; }

        public string Invoice_Number_SL { get; set; }


        public DateTime Invoice_Date_SL { get; set; }
        public decimal Taxable_Value_SL { get; set; }
        public decimal Total_Tax_SL { get; set; }
        public decimal Taxable_Value_Diff_Invoice { get; set; }
        public decimal Tax_Value_Diff_Invoice { get; set; }
        public string Remarks_E_Invoice { get; set; }
        public string Actions_E_Invoice { get; set; }

        public string E_way_Bill_No { get; set; }
        public DateTime E_way_Bill_Date { get; set; }
        public string E_Way_Invoice_Number { get; set; }
        public DateTime E_Way_Invoice_Date { get; set; }
        public string Invoice_Value_E_Way { get; set; }
        public decimal E_Way_Taxable_Value { get; set; }
        public decimal E_Way_Total { get; set; }

        public decimal Taxable_Value_Diff_E_Way { get; set; }
        public decimal Tax_Value_Diff_E_Way { get; set; }
        public string Remarks_E_Way { get; set; }
        public string Actions_E_Way { get; set; }


        public decimal Total_SL_Taxable_value { get; set; }
        public decimal Total_SL_Tax { get; set; }
        public decimal Total_E_Invoice_Taxable_Value { get; set; }
        public decimal Total_E_Invoice_Tax { get; set; }
        public decimal Total_Taxable_Value_Difference_SL_E_Invoices { get; set; }
        public decimal Total_Tax_Difference_SL_E_Invoices { get; set; }
        public decimal Total_E_Way_Taxable_Value { get; set; }
        public decimal Total_E_Way_Tax { get; set; }
        public decimal Total_Taxable_Value_Difference_SL_E_Way { get; set; }
        public decimal Total_Tax_Difference_SL_E_Way { get; set; }
    }
}
