using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.ComparisonReport
{
    public class ComparisonReportSLEWayListModel
    {
        public List<ComparisonReportSLEWayListModel> ComparSLEWayList { get; set; }
        public long Comparison_Report_E_Invoice_Portal_ID { get; set; }
        public string? E_way_Bill_No { get; set; }
        public string E_way_Bill_Date { get; set; }
        public string? E_Way_Invoice_Number { get; set; }
        public string E_Way_Invoice_Date { get; set; }
        public string? Invoice_Value_E_Way { get; set; }
        public decimal E_Way_Taxable_Value { get; set; }
        public decimal E_Way_Total { get; set; }
        public string? Invoice_Number_SL { get; set; }
        public string Invoice_Date_SL { get; set; }
        public decimal Taxable_Value_SL { get; set; }
        public decimal Total_Tax_SL { get; set; }
        public decimal Taxable_Value_Diff_E_Way { get; set; }
        public decimal Tax_Value_Diff_E_Way { get; set; }
        public string? Remarks_E_Way { get; set; }
        public string? Actions_E_Way { get; set; }
    }
}
