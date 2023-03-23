using KSAA.DocumentService.Interfaces;

namespace KSAA.DocumentService.Mapper
{
    public class SupplyRegisterColumns : IFieldBase
    {
        public string DocumentType = "";
        public string InvoiceReceiptDNCNNo = "";
        public string EInvoiceNo = "";
        public string InvoiceReceiptDNCNDate = "";
        public string ShippingBillNo = "";
        public string ShippingBillDate = "";
        public string HSNCode = "";
        public string Quantity = "";
        public string UniqueQuantityCode = "";
        public string Description = "";
        public string PartyName = "";
        public string GSTIN = "";
        public string ReverseCharge = "";
        public string PlaceOfSupplyStateName = "";
        public string ExchangeRateAsPerNotifications = "";
        public string ExchangeRateAsPerShippingBill = "";
        public string TaxableValue = "";
        public string Rate = "";
        public string TaxAmount = "";
        public string CGST = "";
        public string SGSTUTGST = "";
        public string IGST = "";
        public string Cess = "";
        public string TotalInvoiceValue = "";
        public string VehicleNo = "";
        public string EWayBillNo = "";
        public string DispatchLocationCode = "";
        public string PortCode = "";
        public string VoucherNo = "";
        public string AccountingDate = "";
        public string LocationCode = "";
        public string GLCode = "";
        public string TypeOfSupply = "";
        public string GSTPaymentType = "";
        public string Month;
        public string Year;

        public SupplyRegisterColumns()
        {
            //DocumentType = "Document Type";
            //InvoiceReceiptDNCNNo = "Invoice / Receipt / DN / CN No";
            //EInvoiceNo = "E-Invoice No";
            //InvoiceReceiptDNCNDate = "Invoice / Receipt / DN / CN Date";
            //ShippingBillNo = "Shipping bill No";
            //ShippingBillDate = "Shipping bill date";
            //HSNCode = "HSN Code";
            //Quantity = "Quantity";
            //UniqueQuantityCode = "Unique Quantity Code";
            //Description = "Description";
            //PartyName = "Party Name";
            //GSTIN = "GSTIN";
            //ReverseCharge = "Reverse Charge";
            //PlaceOfSupplyStateName = "Place of Supply (Name of State)";
            //ExchangeRateAsPerNotifications = "Exchange Rate as per Notifications";
            //ExchangeRateAsPerShippingBill = "Exchange Rate as per Shipping Bill";
            //TaxableValue = "Taxable value";
            //Rate = "Rate %";
            //TaxAmount = "Tax Amount";
            //CGST = "CGST (Rs)";
            //SGSTUTGST = "SGST / UTGST (Rs)";
            //IGST = "IGST (Rs)";
            //Cess = "Cess (Rs)";
            //TotalInvoiceValue = "Total Invoice Value (Rs)";
            //VehicleNo = "Vehicle No";
            //EWayBillNo = "E-way Bill No";
            //DispatchLocationCode = "Dispatch Location Code";
            //PortCode = "Port Code";
            //VoucherNo = "Voucher No";
            //AccountingDate = "Accounting Date";
            //LocationCode = "Location Code";
            //GLCode = "GL Code";
            //Month = "Month";
            //Year = "Year";

            DocumentType = "Document_Type";
            InvoiceReceiptDNCNNo = "Invoice_No";
            EInvoiceNo = "E-Invoice_No";
            InvoiceReceiptDNCNDate = "Invoice_Date";
            ShippingBillNo = "Shipping_bill_No";
            ShippingBillDate = "Shipping_bill_date";
            HSNCode = "HSN_Code";
            Quantity = "Quantity";
            UniqueQuantityCode = "Unique_Quantity_Code";
            Description = "Description";
            PartyName = "Party_Name";
            GSTIN = "GSTIN";
            ReverseCharge = "Reverse_Charge";
            PlaceOfSupplyStateName = "Place_of_Supply";
            ExchangeRateAsPerNotifications = "Exchange_Rate_as_per_Notifications";
            ExchangeRateAsPerShippingBill = "Exchange_Rate_as_per_Shipping_Bill";
            TaxableValue = "Taxable_value";
            Rate = "Rate";
            TaxAmount = "Tax_Amount";
            CGST = "CGST";
            SGSTUTGST = "SGST_UTGST";
            IGST = "IGST";
            Cess = "Cess";
            TotalInvoiceValue = "Total_Invoice_Value";
            VehicleNo = "Vehicle_No";
            EWayBillNo = "E-way_Bill_No";
            DispatchLocationCode = "Dispatch_Location_Code";
            PortCode = "Port_Code";
            VoucherNo = "Voucher_No";
            AccountingDate = "Accounting_Date";
            LocationCode = "Location_Code";
            GLCode = "GL_Code";
            TypeOfSupply = "Type_of_supply";
            GSTPaymentType = "GST_Payment_Type";
            Month = "Month";
            Year = "Year";
        }
    }
}
