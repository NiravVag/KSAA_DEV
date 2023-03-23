using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_Monthly_GL_Income_Register")]
    public class GLIncomeRegisterViewModel
    {
        public long Id { get; set; }
        public string? ClientCode { get; set; }
        public string? DocumentType { get; set; }
        public string? InvoiceReceiptDNCNNo { get; set; }
        public string? InvoiceReceiptDNCNDate { get; set; }
        public string? CustomerCode { get; set; }
        public string? GSTIN { get; set; }
        public string? GLIncomeCode { get; set; }
        public string? GLIncomeDescription { get; set; }
        public decimal? TaxableValue { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? IGST { get; set; }
        public decimal? CESS { get; set; }
        public string? LocationCode { get; set; }
        public string? VoucherNo { get; set; }
        public string? AccountingDate { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
}
