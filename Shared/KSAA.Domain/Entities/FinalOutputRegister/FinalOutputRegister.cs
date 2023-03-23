using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.FinalOutputRegister
{
    [Table("tbl_Final_Output_Register_KSAA_Template")]
    public class FinalOutputRegister : BaseEntity
    {
        public virtual string? DocumentTypeSL { get; set; }
        public virtual string? InvoiceNumberSL { get; set; }
        public virtual DateTime? InvoiceDateSL { get; set; }
        public virtual string? IRNEInvoices { get; set; }
        public virtual DateTime? IRNDateEInvoices { get; set; }
        public virtual decimal? TaxableValueEInvoice { get; set; }
        public virtual decimal? TaxAmountIGSTCGSTSGSTEInvoice { get; set; }
        public virtual decimal? TaxableValueDifferenceSLEInvoices { get; set; }
        public virtual decimal? TaxDifferenceSLEInvoices { get; set; }
        public virtual string? ShippingBillNoSL { get; set; }
        public virtual DateTime? ShippingBillDateSL { get; set; }
        public virtual string? HSNCodeSL { get; set; }
        public virtual decimal? QuantitySL { get; set; }
        public virtual string? UniqueQuantityCodeSL { get; set; }
        public virtual string? DescriptionSL { get; set; }
        public virtual string? RecieverNameSL { get; set; }
        public virtual string? GSTINUINOfRecipientSL { get; set; }
        public virtual string? ReverseChargeSL { get; set; }
        public virtual string? PlaceOfSupplyStateNameSL { get; set; }
        public virtual string? ExchangeRateAsPerNotificationsSL { get; set; }
        public virtual string? ExchangeRateAsPerShippingBillSL { get; set; }
        public virtual decimal? TaxableValueSL { get; set; }
        public virtual decimal? RateSL { get; set; }
        public virtual decimal? TotalTaxSL { get; set; }
        public virtual decimal? CentralTaxSL { get; set; }
        public virtual decimal? StateUTTaxSL { get; set; }
        public virtual decimal? IntegratedTaxSL { get; set; }
        public virtual decimal? CessAmountSL { get; set; }
        public virtual decimal? TotalInvoiceValueRsSL { get; set; }
        public virtual string? VehicleNoSL { get; set; }
        public virtual string? EWayBillNoSL { get; set; }
        public virtual string? DispatchLocationCodeSL { get; set; }
        public virtual string? PortCodeSL { get; set; }
        public virtual string? VoucherNoSL { get; set; }
        public virtual DateTime? AccountingDateSL { get; set; }
        public virtual string? LocationCodeSL { get; set; }
        public virtual string? GLCodeSL { get; set; }
        public virtual string? EInvoiceNoSL { get; set; }
        public virtual DateTime? EInvoiceDateSL { get; set; }
        public virtual string? EWayBillNo { get; set; }
        public virtual DateTime? EWayDateSL { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
        public virtual string? TypeOfSupplySL { get; set; }
        public virtual string? GSTPaymentTypeSL { get; set; }
    }
}
