using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.DocumentUpload
{
    [Table("tbl_Liability_Ledger")]
    public class LiabilityLedger : BaseEntity
    {
        public virtual string? ClientCode { get; set; }
        public virtual string? GLCode { get; set; }
        public virtual string? GLDescription { get; set; }
        public virtual string? DocumentType { get; set; }
        public virtual string? InvoiceReceiptDNCNNo { get; set; }
        public virtual string? EInvoiceNo { get; set; }
        public virtual decimal? CGST { get; set; }
        public virtual decimal? SGST { get; set; }
        public virtual decimal? IGST { get; set; }
        public virtual decimal? CESS { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
    }
}
