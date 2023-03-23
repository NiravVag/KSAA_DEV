using KSAA.DocumentService.Interfaces;

namespace KSAA.DocumentService.Mapper
{
    public class GLIncomeRegisterColumns : IFieldBase
    {
        public string DocumentType;
        public string InvoiceReceiptDNCNNo;
        public string InvoiceReceiptDNCNDate;
        public string CustomerCode;
        public string GSTIN;
        public string GLIncomeCode;
        public string GLIncomeDescription;
        public string TaxableValue;
        public string CGST;
        public string SGST;
        public string IGST;
        public string CESS;
        public string LocationCode;
        public string VoucherNo;
        public string AccountingDate;
        public string Month;
        public string Year;

        public GLIncomeRegisterColumns()
        {
            //DocumentType = "[Document Type]";
            //InvoiceReceiptDNCNNo = "[Invoice / Receipt / DN / CN No]";
            //InvoiceReceiptDNCNDate = "[Invoice / Receipt / DN / CN Date]";
            //CustomerCode = "[Customer Code]";
            //GSTIN = "[GSTIN]";
            //GLIncomeCode = "[GL Income Code]";
            //GLIncomeDescription = "[GL Income Description]";
            //TaxableValue = "[Taxable Value]";
            //CGST = "[CGST]";
            //SGST = "[SGST]";
            //IGST = "[IGST]";
            //CESS = "[CESS]";
            //LocationCode = "[Location Code]";
            //VoucherNo = "[Voucher No]";
            //AccountingDate = "[Accounting Date]";
            //Month = "Month";
            //Year = "Year";

            DocumentType = "[Document_Type]";
            InvoiceReceiptDNCNNo = "[Invoice_No]";
            InvoiceReceiptDNCNDate = "[Invoice_Date]";
            CustomerCode = "[Customer_Code]";
            GSTIN = "[GSTIN]";
            GLIncomeCode = "[GL_Income_Code]";
            GLIncomeDescription = "[GL_Income_Description]";
            TaxableValue = "[Taxable_Value]";
            CGST = "[CGST]";
            SGST = "[SGST]";
            IGST = "[IGST]";
            CESS = "[CESS]";
            LocationCode = "[Location_Code]";
            VoucherNo = "[Voucher_No]";
            AccountingDate = "[Accounting_Date]";
            Month = "Month";
            Year = "Year";
        }
    }
}
