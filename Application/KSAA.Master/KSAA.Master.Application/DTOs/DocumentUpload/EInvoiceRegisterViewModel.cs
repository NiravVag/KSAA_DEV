using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_E_Invoice_Register")]
    public class EInvoiceRegisterViewModel
    {
        public long Id { get; set; }
        public string? ClientCode { get; set; }
        public string? GSTINUINOfRecipient { get; set; }
        public string? RecieverName { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? InvoiceDate { get; set; }
        public string? InvoiceValue { get; set; }
        public string? PlaceOfSupply { get; set; }
        public string? ReverseCharge { get; set; }
        public decimal? ApplicableofTaxRate { get; set; }
        public string? InvoiceType { get; set; }
        public string? ECommerceGSTIN { get; set; }
        public decimal? Rate { get; set; }
        public decimal? TaxableValue { get; set; }
        public decimal? IntegratedTax { get; set; }
        public decimal? CentralTax { get; set; }
        public decimal? StateUTTax { get; set; }
        public decimal? CessAmount { get; set; }
        public string? IRN { get; set; }
        public string? IRNDate { get; set; }
        public string? EInvoiceStatus { get; set; }
        public string? GSTR1AutoPopulationDeletionUponCancellationDate { get; set; }
        public string? GSTR1AutoPopulationDeletionStatus { get; set; }
        public string? ErrorInAutoPopulationDeletion { get; set; }
        public string? InvoiceType2 { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
}
