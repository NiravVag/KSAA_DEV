using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.DocumentUpload
{
    [Table("tbl_Monthly_GL_Income_Register")]
    public class GLIncomeRegister : BaseEntity
    {
        public virtual string? ClientCode { get; set; }
        public virtual string? DocumentType { get; set; }
        public virtual string? InvoiceReceiptDNCNNo { get; set; }
        public virtual DateTime InvoiceReceiptDNCNDate { get; set; }
        public virtual string? CustomerCode { get; set; }
        public virtual string? GSTIN { get; set; }
        public virtual string? GLIncomeCode { get; set; }
        public virtual string? GLIncomeDescription { get; set; }
        public virtual decimal? TaxableValue { get; set; }
        public virtual decimal? CGST { get; set; }
        public virtual decimal? SGST { get; set; }
        public virtual decimal? IGST { get; set; }
        public virtual decimal? CESS { get; set; }
        public virtual string? LocationCode { get; set; }
        public virtual string? VoucherNo { get; set; }
        public virtual DateTime AccountingDate { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
    }
}