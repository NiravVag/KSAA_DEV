using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.GL_Income
{
    public class ComparisonReportSLEInvoice : BaseEntity
    {
        public virtual string? E_Invoice_Bill_No { get; set; }
        public virtual DateTime E_invoice_Bill_Date { get; set; }
        public virtual string? Invoice_Number { get; set; }
        public virtual DateTime Invoice_Date { get; set; }
        public virtual string? Invoice_Value { get; set; }
        public virtual decimal Taxable_Value_E_Invoice { get; set; }
        public virtual decimal Total_Tax_E_Invoice { get; set; }
        public virtual string? Invoice_Number_SL { get; set; }
        public virtual DateTime Invoice_Date_SL { get; set; }
        public virtual decimal Taxable_Value_SL { get; set; }
        public virtual decimal Total_Tax_SL { get; set; }
        public virtual decimal Taxable_Value_Diff_Invoice { get; set; }
        public virtual decimal Tax_Value_Diff_Invoice { get; set; }
        public virtual string? Remarks_E_Invoice { get; set; }
        public virtual string? Actions_E_Invoice { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
    }
}
