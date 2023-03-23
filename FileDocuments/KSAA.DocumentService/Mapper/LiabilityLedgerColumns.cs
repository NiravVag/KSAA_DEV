using KSAA.DocumentService.Interfaces;

namespace KSAA.DocumentService.Mapper
{
    public class LiabilityLedgerColumns : IFieldBase
    {
        public string GLCode = "";
        public string GLDescription = "";
        public string DocumentType = "";
        public string InvoiceReceiptDNCNNo = "";
        public string EInvoiceNo = "";
        public string CGST = "";
        public string SGST = "";
        public string IGST = "";
        public string CESS = "";
        public string Month;
        public string Year;
        public LiabilityLedgerColumns() 
        {
            //GLCode = "GL Code";
            //GLDescription = "GL Description";
            //DocumentType = "Document Type";
            //InvoiceReceiptDNCNNo = "Invoice / Receipt / DN / CN No";
            //EInvoiceNo = "E-Invoice No";
            //CGST = "CGST";
            //SGST = "SGST";
            //IGST = "IGST";
            //CESS = "Cess";
            //Month = "Month";
            //Year = "Year";

            GLCode = "GL_Code";
            GLDescription = "GL_Description";
            DocumentType = "Document_Type";
            InvoiceReceiptDNCNNo = "Invoice_No";
            EInvoiceNo = "E-Invoice_No";
            CGST = "CGST";
            SGST = "SGST";
            IGST = "IGST";
            CESS = "Cess";
            Month = "Month";
            Year = "Year";
        }
    }
}
