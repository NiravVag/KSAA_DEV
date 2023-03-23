using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.OutputRegister
{
    public class OutputRegister : BaseEntity
    {
        public virtual string? DocumentType { get; set; }
        public virtual string? InvoiceNumber { get; set; }
        public virtual string? InvoiceNumberSL { get; set; }
        public virtual DateTime InvoiceDate { get; set; }
        public virtual string? E_InvoiceNo { get; set; }
        public virtual DateTime EInvoiceDate { get; set; }
        public virtual decimal? EInvoiceTotalAmount { get; set; }
        public virtual decimal? EInvoiceTaxAmount { get; set; }
        public virtual decimal? EInvoiceAmountDifferent { get; set; }
        public virtual decimal? EInvoiceTaxDifferent { get; set; }
        public virtual string? ShippingBillNo { get; set; }
        public virtual DateTime ShippingBillDate { get; set; }
        public virtual string? HSNCode { get; set; }
        public virtual decimal? Quantity { get; set; }
        public virtual string? UniqueQuantityCode { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? PartyName { get; set; }
        public virtual string? GSTIN { get; set; }
        public virtual string? ReverseCharge { get; set; }
        public virtual string? PlaceOfSupplyStateName { get; set; }
        public virtual string? Exchange_RateAsPerNotifications { get; set; }
        public virtual string? Exchange_Rate_As_Per_Shipping_Bill { get; set; }
        public virtual decimal? TaxableValue { get; set; }
        public virtual string? Rate { get; set; }
        public virtual decimal? TotalTax { get; set; }
        public virtual decimal? CentralTax { get; set; }
        public virtual decimal? StateUTTax { get; set; }
        public virtual decimal? IntegratedTax { get; set; }
        public virtual decimal? CessAmount { get; set; }
        public virtual decimal? TotalInvoiceValue_Rs { get; set; }
        public virtual string? VehicleNo { get; set; }
        public virtual string? EWayBillNo { get; set; }
        public virtual string? DispatchLocationCode { get; set; }
        public virtual string? PortCode { get; set; }
        public virtual string? VoucherNo { get; set; }
        public virtual DateTime AccountingDate { get; set; }
        public virtual string? LocationCode { get; set; }
        public virtual string? GL_Code { get; set; }
        public virtual string? EInvoiceNo2 { get; set; }
        public virtual DateTime EInvoiceDate2 { get; set; }
        public virtual string? EWayBillNo2 { get; set; }
        public virtual DateTime EWayDate2 { get; set; }
        public virtual string? AdvanceReceiptNumber { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }

        public virtual decimal? TaxableValueSL { get; set; }
        public virtual decimal? CentralTaxSL { get; set; }
        public virtual decimal? StateUTTaxSL { get; set; }
        public virtual decimal? IntegratedTaxSL { get; set; }
        public virtual bool IsInvoiceTagged { get; set; }
        public virtual bool IsInvoiceAmended { get; set; }
        public virtual string? RemarksInvoiceAmended { get; set; }
    }
}
