using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.GL_Income
{
    public class SupplyModel
    {
        public string? Client_Code { get; set; }
        public string? GL_Code { get; set; }
        public string? Invoice_No { get; set; }
        public string? Accounting_voucher { get; set; }
        public decimal? Amount { get; set; }
        public string? Description { get; set; }
        public string? Date { get; set; }
        public string? HSN_SAC { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? IGST { get; set; }
        public decimal? CESS { get; set; }
        public string? GSTIN { get; set; }
        public string? Remarks { get; set; }
        public string? Action { get; set; }
        public string? DataSource { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
}
