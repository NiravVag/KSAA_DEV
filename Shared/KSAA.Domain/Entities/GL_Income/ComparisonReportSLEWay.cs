using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.GL_Income
{
    public class ComparisonReportSLEWay : BaseEntity
    {
        public virtual string? E_way_Bill_No { get; set; }
        public virtual DateTime E_way_Bill_Date { get; set; }
        public virtual string? E_Way_Invoice_Number { get; set; }
        public virtual DateTime E_Way_Invoice_Date { get; set; }
        public virtual string? Invoice_Value_E_Way { get; set; }
        public virtual decimal E_Way_Taxable_Value { get; set; }
        public virtual decimal E_Way_Total { get; set; }
        public virtual decimal Taxable_Value_Diff_E_Way { get; set; }
        public virtual decimal Tax_Value_Diff_E_Way { get; set; }
        public virtual string? Remarks_E_Way { get; set; }
        public virtual string? Actions_E_Way { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
    }
}