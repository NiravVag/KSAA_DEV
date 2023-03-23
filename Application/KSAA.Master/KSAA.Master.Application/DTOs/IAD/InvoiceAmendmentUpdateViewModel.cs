using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.IAD
{
    public class InvoiceAmendmentUpdateViewModel
    {
        public string InvoiceNumber { get; set; }
        public string? ClientCode { get; set; }
        public string? RevisedGSTIN { get; set; }
        public string? RevisedPOS { get; set; }
        public string? RevisedDocumentType { get; set; }
        public string? RevisedInvoiceNoDebitCreditNote { get; set; }
        public string? RevisedInvoiceDate { get; set; }
        public string? RevisedShippingBillNo { get; set; }
        public string? RevisedShippingBillDate { get; set; }
        public string? RevisedPortCode { get; set; }
        public string? RevisedGSTPaymentType { get; set; }
        public string? RevisedTaxableValue { get; set; }
        public string? RevisedHSNSAC { get; set; }
        public string? RevisedRate { get; set; }
        public string? RevisedCess { get; set; }
        public string? RevisedCGST { get; set; }
        public string? RevisedSGST { get; set; }
        public string? RevisedIGST { get; set; }
        public string? RevisedTotalTax { get; set; }
        public string? RemarksforChangeinLiability { get; set; }
        public string? GSTR1presentationRemark { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
}
