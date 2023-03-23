using KSAA.DocumentService.Interfaces;

namespace KSAA.DocumentService.Mapper
{
    public class AdvanceReceivedColumns : IFieldBase
    {
        public string ReceiptNumber = "";
        public string DateofReceipt = "";
        public string GSTIN = "";
        public string POS = "";
        public string TypeOfSupply = "";
        public string TaxableValue = "";
        public string Rate = "";
        public string CessPercentage = "";
        public string CGST = "";
        public string SGST = "";
        public string IGST = "";
        public string Cess = "";
        public string TotalTax = "";
        public string TotalInvoiceValue = "";
        public string TotalAmendmentTaxableValue = "";
        public string Month = "";
        public string Year = "";

        public AdvanceReceivedColumns()
        {
            //ReceiptNumber = "[Receipt_Number]";
            //DateofReceipt = "[Date_of_Receipt]";
            //GSTIN = "[GSTIN]";
            //POS = "[POS]";
            //TypeOfSupply = "[Type_Of_Supply]";
            //TaxableValue = "[Taxable_Value]";
            //Rate = "[Rate]";
            //CessPercentage = "[Cess_Percentage]";
            //CGST = "[CGST]";
            //SGST = "[SGST]";
            //IGST = "[IGST]";
            //CESS = "[CESS]";
            //TotalTax = "[Total_Tax]";
            //TotalInvoiceValue = "[Total_Invoice_Value]";
            //Month = "Month";
            //Year = "Year";

            ReceiptNumber = "[ReceiptNumber]";
            DateofReceipt = "[DateofReceipt]";
            GSTIN = "[GSTIN]";
            POS = "[POS]";
            TypeOfSupply = "[TypeOfSupply]";
            TaxableValue = "[TaxableValue]";
            Rate = "[Rate]";
            CessPercentage = "[CessPercentage]";
            CGST = "[CGST]";
            SGST = "[SGST]";
            IGST = "[IGST]";
            Cess = "[Cess]";
            TotalTax = "[TotalTax]";
            TotalInvoiceValue = "[TotalInvoiceValue]";
            TotalAmendmentTaxableValue = "[TotalAmendmentTaxableValue]";
            Month = "Month";
            Year = "Year";
        }
    }
}
