using KSAA.DocumentService.Interfaces;

namespace KSAA.DocumentService.Mapper
{
    public class EInvoiceRegisterColumns : IFieldBase
    {
        public string GSTINUINOfRecipient = "";
        public string RecieverName = "";
        public string InvoiceNumber = "";
        public string InvoiceDate = "";
        public string InvoiceValue = "";
        public string PlaceOfSupply = "";
        public string ReverseCharge = "";
        public string ApplicableofTaxRate = "";
        public string InvoiceType = "";
        public string ECommerceGSTIN = "";
        public string Rate = "";
        public string TaxableValue = "";
        public string IntegratedTax = "";
        public string CentralTax = "";
        public string StateUTTax = "";
        public string CessAmount = "";
        public string IRN = "";
        public string IRNDate = "";
        public string EInvoiceStatus = "";
        public string GSTR1AutoPopulationDeletionUponCancellationDate = "";
        public string GSTR1AutoPopulationDeletionStatus = "";
        public string ErrorInAutoPopulationDeletion = "";
        public string InvoiceType2 = "";
        public string Month;
        public string Year;
        public EInvoiceRegisterColumns() 
        {
            GSTINUINOfRecipient = "GSTIN_UIN_of_Recipient";
            RecieverName = "Reciever_Name";
            InvoiceNumber = "Invoice_number";
            InvoiceDate = "Invoice_date";
            InvoiceValue = "Invoice_value";
            PlaceOfSupply = "Place_of_Supply";
            ReverseCharge = "Reverse_Charge";
            ApplicableofTaxRate = "Applicable_of_Tax_Rate";
            InvoiceType = "Invoice_type";
            ECommerceGSTIN = "E-Commerce_GSTIN";
            Rate = "Rate";
            TaxableValue = "Taxable_Value";
            IntegratedTax = "Integrated_Tax";
            CentralTax = "Central_Tax";
            StateUTTax = "State_UT_Tax";
            CessAmount = "Cess_Amount";
            IRN = "IRN";
            IRNDate = "IRN_date";
            EInvoiceStatus = "E-invoice_status";
            GSTR1AutoPopulationDeletionUponCancellationDate = "GSTR-1_cancellation_date";
            GSTR1AutoPopulationDeletionStatus = "GSTR-1_deletion_status";
            ErrorInAutoPopulationDeletion = "Error_in_deletion";
            InvoiceType2 = "Invoice_type_2";
            Month = "Month";
            Year = "Year";
        }
    }
}
