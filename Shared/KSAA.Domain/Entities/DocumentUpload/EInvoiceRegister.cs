using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.DocumentUpload
{
    [Table("tbl_E_Invoice_Register")]
    public class EInvoiceRegister : BaseEntity
    {
        public virtual string? ClientCode { get; set; }
        public virtual string? GSTINUINOfRecipient { get; set; }
        public virtual string? RecieverName { get; set; }
        public virtual string? InvoiceNumber { get; set; }
        public virtual DateTime? InvoiceDate { get; set; }
        public virtual string? InvoiceValue { get; set; }
        public virtual string? PlaceOfSupply { get; set; }
        public virtual string? ReverseCharge { get; set; }
        public virtual decimal? ApplicableofTaxRate { get; set; }
        public virtual string? InvoiceType { get; set; }
        public virtual string? ECommerceGSTIN { get; set; }
        public virtual decimal? Rate { get; set; }
        public virtual decimal? TaxableValue { get; set; }
        public virtual decimal? IntegratedTax { get; set; }
        public virtual decimal? CentralTax { get; set; }
        public virtual decimal? StateUTTax { get; set; }
        public virtual decimal? CessAmount { get; set; }
        public virtual string? IRN { get; set; }
        public virtual DateTime? IRNDate { get; set; }
        public virtual string? EInvoiceStatus { get; set; }
        public virtual DateTime? GSTR1AutoPopulationDeletionUponCancellationDate { get; set; }
        public virtual string? GSTR1AutoPopulationDeletionStatus { get; set; }
        public virtual string? ErrorInAutoPopulationDeletion { get; set; }
        public virtual string? InvoiceType2 { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
    }
}
