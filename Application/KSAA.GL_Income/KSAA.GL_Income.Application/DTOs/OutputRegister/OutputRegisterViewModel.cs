using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.OutputRegister
{
    public class OutputRegisterViewModel
    {
        public List<OutputRegisterViewModel> OutputRegisterGrid { get; set; }
        public long Id { get; set; }
        public string? DocumentType { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? InvoiceNumberSL { get; set; }
        public string? InvoiceDate { get; set; }
        public string? E_InvoiceNo { get; set; }
        public string? EInvoiceDate { get; set; }
        public decimal? EInvoiceTotalAmount { get; set; }
        public decimal? EInvoiceTaxAmount { get; set; }
        public decimal? EInvoiceAmountDifferent { get; set; }
        public decimal? EInvoiceTaxDifferent { get; set; }
        public string? ShippingBillNo { get; set; }
        public string? ShippingBillDate { get; set; }
        public string? HSNCode { get; set; }
        public decimal? Quantity { get; set; }
        public string? UniqueQuantityCode { get; set; }
        public string? Description { get; set; }
        public string? PartyName { get; set; }
        public string? GSTIN { get; set; }
        public string? ReverseCharge { get; set; }
        public string? PlaceOfSupplyStateName { get; set; }
        public string? Exchange_RateAsPerNotifications { get; set; }
        public string? Exchange_Rate_As_Per_Shipping_Bill { get; set; }
        public decimal? TaxableValue { get; set; }
        public string? Rate { get; set; }
        public decimal? TotalTax { get; set; }
        public decimal? CentralTax { get; set; }
        public decimal? StateUTTax { get; set; }
        public decimal? IntegratedTax { get; set; }
        public decimal? CessAmount { get; set; }
        public decimal? TotalInvoiceValue_Rs { get; set; }
        public string? VehicleNo { get; set; }
        public string? EWayBillNo { get; set; }
        public string? DispatchLocationCode { get; set; }
        public string? PortCode { get; set; }
        public string? VoucherNo { get; set; }
        public string? AccountingDate { get; set; }
        public string? LocationCode { get; set; }
        public string? GL_Code { get; set; }
        public string? EInvoiceNo2 { get; set; }
        public string? EInvoiceDate2 { get; set; }
        public string? EWayBillNo2 { get; set; }
        public string? EWayDate2 { get; set; }
        public string? AdvanceReceiptNumber { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }

        public decimal? TaxableValueSL { get; set; }
        public decimal? CentralTaxSL { get; set; }
        public decimal? StateUTTaxSL { get; set; }
        public decimal? IntegratedTaxSL { get; set; }
        public bool IsInvoiceTagged { get; set; }
        public bool IsInvoiceAmended { get; set; }
        public string? RemarksInvoiceAmended { get; set; }
    }
}
