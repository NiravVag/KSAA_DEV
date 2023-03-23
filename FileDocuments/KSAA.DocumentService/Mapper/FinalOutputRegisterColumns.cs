using KSAA.DocumentService.Interfaces;

namespace KSAA.DocumentService.Mapper
{
    public class FinalOutputRegisterColumns : IFieldBase
    {
        public  string DocumentTypeSL = "";
        public  string InvoiceNumberSL = "";
        public  string InvoiceDateSL = "";
        public  string IRNEInvoices = "";
        public  string IRNDateEInvoices = "";
        public  string TaxableValueEInvoice = "";
        public  string TaxAmountIGSTCGSTSGSTEInvoice = "";
        public  string TaxableValueDifferenceSLEInvoices = "";
        public  string TaxDifferenceSLEInvoices = "";
        public  string ShippingBillNoSL = "";
        public  string ShippingBillDateSL = "";
        public  string HSNCodeSL = "";
        public  string QuantitySL = "";
        public  string UniqueQuantityCodeSL = "";
        public  string DescriptionSL = "";
        public  string RecieverNameSL = "";
        public  string GSTINUINOfRecipientSL = "";
        public  string ReverseChargeSL = "";
        public  string PlaceOfSupplyStateNameSL = "";
        public  string ExchangeRateAsPerNotificationsSL = "";
        public  string ExchangeRateAsPerShippingBillSL = "";
        public  string TaxableValueSL = "";
        public  string RateSL = "";
        public  string TotalTaxSL = "";
        public  string CentralTaxSL = "";
        public  string StateUTTaxSL = "";
        public  string IntegratedTaxSL = "";
        public  string CessAmountSL = "";
        public  string TotalInvoiceValueRsSL = "";
        public  string VehicleNoSL = "";
        public  string EWayBillNo = "";
        public  string DispatchLocationCodeSL = "";
        public  string PortCodeSL = "";
        public  string VoucherNoSL = "";
        public  string AccountingDateSL = "";
        public  string LocationCodeSL = "";
        public  string GLCodeSL = "";
        public  string EInvoiceNoSL = "";
        public  string EInvoiceDateSL = "";
        public  string EWayBillNoSL = "";
        public  string EWayDateSL = "";
        public  string Month = "";
        public  string Year = "";
        public FinalOutputRegisterColumns()
        {
            DocumentTypeSL = "[Document_Type]";
            InvoiceNumberSL = "[Invoice_Number]";
            InvoiceDateSL = "[Invoice_Date]";
            IRNEInvoices = "[E_Invoice_No]";
            IRNDateEInvoices = "[E_Invoice_Date]";
            TaxableValueEInvoice = "[E_Invoice_Total_Amount]";
            TaxAmountIGSTCGSTSGSTEInvoice = "[E_Invoice_Tax_Amount]";
            TaxableValueDifferenceSLEInvoices = "[E_Invoice_Amount_Different]";
            TaxDifferenceSLEInvoices = "[E_Invoice_Tax_Different]";
            ShippingBillNoSL = "[Shipping_Bill_No]";
            ShippingBillDateSL = "[Shipping_Bill_Date]";
            HSNCodeSL = "[HSN_Code]";
            QuantitySL = "[Quantity]";
            UniqueQuantityCodeSL = "[Unique_Quantity_Code]";
            DescriptionSL = "[Description]";
            RecieverNameSL = "[Party_Name]";
            GSTINUINOfRecipientSL = "[GSTIN]";
            ReverseChargeSL = "[Reverse_Charge]";
            PlaceOfSupplyStateNameSL = "[Place_Of_Supply_State_Name]";
            ExchangeRateAsPerNotificationsSL = "[Exchange_Rate_As_Per_Notifications]";
            ExchangeRateAsPerShippingBillSL = "[Exchange_Rate_As_Per_Shipping_Bill]";
            TaxableValueSL = "[Taxable_Value]";
            RateSL = "[Rate]";
            TotalTaxSL = "[Total_Tax]";
            CentralTaxSL = "[Central_Tax]";
            StateUTTaxSL = "[State_UT_Tax]";
            IntegratedTaxSL = "[Integrated_Tax]";
            CessAmountSL = "[Cess_Amount]";
            TotalInvoiceValueRsSL = "[Total_Invoice_Value_Rs]";
            VehicleNoSL = "[Vehicle_No]";
            EWayBillNo = "[E_Way_Bill_No]";
            DispatchLocationCodeSL = "[Dispatch_Location_Code]";
            PortCodeSL = "[Port_Code]";
            VoucherNoSL = "[Voucher_No]";
            AccountingDateSL = "[Accounting_Date]";
            LocationCodeSL = "[Location_Code]";
            GLCodeSL = "[GL_Code]";
            EInvoiceNoSL = "[E_Invoice_No_2]";
            EInvoiceDateSL = "[E_Invoice_Date_2]";
            EWayBillNoSL = "[E_Way_Bill_No_2]";
            EWayDateSL = "[E_Way_Date_2]";
            Month = "[Month]";
            Year = "[Year]";
        }
    }
}
