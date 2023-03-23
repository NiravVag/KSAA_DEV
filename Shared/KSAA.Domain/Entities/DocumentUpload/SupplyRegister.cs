using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.DocumentUpload
{
    [Table("tbl_Monthly_Supply_Register")]
    public class SupplyRegister : BaseEntity
    {
        public virtual string? DocumentType { get; set; }
        public virtual string? InvoiceReceiptDNCNNo { get; set; }
        public virtual string? EInvoiceNo { get; set; }
        public virtual DateTime? InvoiceReceiptDNCNDate { get; set; }
        public virtual string? ShippingBillNo { get; set; }
        public virtual DateTime? ShippingBillDate { get; set; }
        public virtual string? HSNCode { get; set; }
        public virtual decimal? Quantity { get; set; }
        public virtual string? UniqueQuantityCode { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? PartyName { get; set; }
        public virtual string? GSTIN { get; set; }
        public virtual string? ReverseCharge { get; set; }
        public virtual string? PlaceOfSupplyStateName { get; set; }
        public virtual string? ExchangeRateAsPerNotifications { get; set; }
        public virtual string? ExchangeRateAsPerShippingBill { get; set; }
        public virtual string? ClientCode { get; set; }
        public virtual decimal? TaxableValue { get; set; }
        public virtual decimal? Rate { get; set; }
        public virtual decimal? TaxAmount { get; set; }
        public virtual decimal? CGST { get; set; }
        public virtual decimal? SGSTUTGST { get; set; }
        public virtual decimal? IGST { get; set; }
        public virtual decimal? Cess { get; set; }
        public virtual decimal? TotalInvoiceValue { get; set; }
        public virtual string? VehicleNo { get; set; }
        public virtual DateTime? EInvoiceDate { get; set; }
        public virtual string? EWayBillNo { get; set; }
        public virtual DateTime? EWayDate { get; set; }
        public virtual string? DispatchLocationCode { get; set; }
        public virtual string? PortCode { get; set; }
        public virtual string? VoucherNo { get; set; }
        public virtual DateTime? AccountingDate { get; set; }
        public virtual string? LocationCode { get; set; }
        public virtual string? GLCode { get; set; }
        public virtual string? TypeOfSupply { get; set; }
        public virtual string? GSTPaymentType { get; set; }
        public virtual string? Month { get; set; }
        public virtual string? Year { get; set; }
        //public virtual string? Tracking { get; set; }
        //public virtual string? CorrectionComment { get; set; }
        //public virtual string? CreatedBy { get; set; }
        //public virtual DateTime CreatedOn { get; set; }
        //public virtual string? ModifiedBy { get; set; }
        //public virtual DateTime ModifiedOn { get; set; }
        //public virtual IsActive sActive { get; set; }
        //public virtual string? IP { get; set; }
        //public virtual string? BrowserCase { get; set; }
    }
}
