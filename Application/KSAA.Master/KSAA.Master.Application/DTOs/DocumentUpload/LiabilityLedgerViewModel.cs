using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_Liability_Ledger")]
    public class LiabilityLedgerViewModel
    {
        public long Id { get; set; }
        public string? ClientCode { get; set; }
        public string? GLCode { get; set; }
        public string? GLDescription { get; set; }
        public string? DocumentType { get; set; }
        public string? InvoiceReceiptDNCNNo { get; set; }
        public string? EInvoiceNo { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGST { get; set; }
        public decimal? IGST { get; set; }
        public decimal? CESS { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
}
