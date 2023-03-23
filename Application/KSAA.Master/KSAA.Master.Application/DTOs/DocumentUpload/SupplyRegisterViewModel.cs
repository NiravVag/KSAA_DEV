using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.DocumentUpload
{
    [Table("tbl_Monthly_Supply_Register")]
    public class SupplyRegisterViewModel
    {
        public long Id { get; set; }
        public string? ClientCode { get; set; }
        public string? DocumentType { get; set; }
        public string? InvoiceReceiptDNCNNo { get; set; }
        public string? EInvoiceNo { get; set; }
        public string? InvoiceReceiptDNCNDate { get; set; }
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
        public string? ExchangeRateAsPerNotifications { get; set; }
        public string? ExchangeRateAsPerShippingBill { get; set; }
        public decimal? TaxableValue { get; set; }
        public decimal? Rate { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? CGST { get; set; }
        public decimal? SGSTUTGST { get; set; }
        public decimal? IGST { get; set; }
        public decimal? Cess { get; set; }
        public decimal? TotalInvoiceValue { get; set; }
        public string? VehicleNo { get; set; }
        public string? EInvoiceDate { get; set; }
        public string? EWayBillNo { get; set; }
        public string? EWayDate { get; set; }
        public string? DispatchLocationCode { get; set; }
        public string? PortCode { get; set; }
        public string? VoucherNo { get; set; }
        public string? AccountingDate { get; set; }
        public string? LocationCode { get; set; }
        public string? GLCode { get; set; }
        public string? TypeOfSupply { get; set; }
        public string? GSTPaymentType { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
        //public string? Tracking { get; set; }
        //public string? CorrectionComment { get; set; }
        //public string? CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string? ModifiedBy { get; set; }
        //public DateTime ModifiedOn { get; set; }
        //public IsActive sActive { get; set; }
        //public string? IP { get; set; }
        //public string? BrowserCase { get; set; }
    }
}
