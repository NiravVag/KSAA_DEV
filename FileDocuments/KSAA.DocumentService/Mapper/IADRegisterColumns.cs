using KSAA.DocumentService.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KSAA.DocumentService.Mapper
{
    public class IADRegisterColumns : IFieldBase
    {
        public string OriginalInvoiceAgainstCNDNReceiptNoAgaisntrefundno = "" ;
        public string? RevisedGSTIN = "" ;
        public string? RevisedPOS = "" ;
        public string? RevisedDocumentType = "" ;
        public string? RevisedInvoiceNoDebitCreditNote = "" ;
        public string? RevisedInvoiceDate = "" ;
        public string? RevisedShippingBillNo = "" ;
        public string? RevisedShippingBillDate = "" ;
        public string? RevisedPortCode = "" ;
        public string? RevisedGSTPaymentType = "" ;
        public string? RevisedTaxableValue = "" ;
        public string? RevisedHSNSAC = "" ;
        public string? RevisedRate = "" ;
        public string? RevisedCess = "" ;
        public string? RevisedCGST = "" ;
        public string? RevisedSGST = "" ;
        public string? RevisedIGST = "" ;
        public string? RevisedTotalTax = "" ;
        public string? RemarksforChangeinLiability = "" ;
        public string? GSTR1presentationRemark = "" ;

        //public string DocumentType = "" ;
        //public string BillingState = "" ;
        //public string OriginalMonth = "" ;
        //public string OriginalInvoiceAgainstCNDNReceiptNoAgaisntrefundno = "" ;
        //public string dateAgaisntCNDNReceiptdateAgainstrefunddate = "" ;
        //public string InvoiceNoDebitCreditNote = "" ;
        //public string InvoiceDate = "" ;
        //public string ShippingBillNo = "" ;
        //public string ShippingBillDate = "" ;
        //public string PortCode = "" ;
        //public string PartyName = "" ;
        //public string GSTIN = "" ;
        //public string CategoryRegURDCompositionDealerUIN = "" ;
        //public string PlaceofSupply = "" ;
        //public string Type = "" ;
        //public string Taxablevalue = "" ;
        //public string Rate = "" ;
        //public string Cess = "" ;
        //public string GSTPaymentType = "" ;
        //public string TaxAmount = "" ;
        //public string CGSTRs = "" ;
        //public string SGSTUTGSTRs = "" ;
        //public string IGSTRs = "" ;
        //public string TotalInvoiceValueRs = "" ;
        //public string UpdatedGSTIN = "" ;
        //public string UpdatedPOS = "" ;
        //public string RevisedDocumentType = "" ;
        //public string RevisedUpdatedInvoiceNoDebitCreditNote = "" ;
        //public string RevisedUpdatedInvoiceDate = "" ;
        //public string RevisedShippingBillNo = "" ;
        //public string RevisedShippingBillDate = "" ;
        //public string RevisedPortCode = "" ;
        //public string RevisedGSTPaymentType = "" ;
        //public string RevisedTaxableValue = "" ;
        //public string RevisedHSNSAC = "" ;
        //public string RevisedRate = "" ;
        //public string RevisedCess = "" ;
        //public string CGST = "" ;
        //public string SGST = "" ;
        //public string IGST = "" ;
        //public string TotalTax = "" ;
        //public string RemarksforChangeinLiability = "" ;
        //public string GSTR1presentationRemark = "" ;
        //public string Month;
        //public string Year;


       /* public string UpdatedGSTIN = "";
        public string UpdatedPOS = "";
        public string RevisedDocumentType = "";
        public string RevisedUpdatedInvoiceNoDebitCreditNote = "";
        public string RevisedUpdatedInvoiceDate = "";
        public string ClientCode = "";
        public string InvoiceNumber = "";
        public string Month;
        public string Year;*/

        public IADRegisterColumns()
        {

            OriginalInvoiceAgainstCNDNReceiptNoAgaisntrefundno = "[Original_Invoice_Against_CN_DN_Receipt_No_Agaisnt_refund_no]";
            RevisedGSTIN = "[Revised_GSTIN]";
            RevisedPOS = "[Revised_POS]";
            RevisedDocumentType = "[Revised_Document_Type]";
            RevisedInvoiceNoDebitCreditNote = "[Revised_Invoice_No_Debit_Credit_Note]";
            RevisedInvoiceDate = "[Revised_Invoice_Date]";
            RevisedShippingBillNo = "[Revised_Shipping_Bill_No]";
            RevisedShippingBillDate = "[Revised_Shipping_Bill_Date]";
            RevisedPortCode = "[Revised_Port_Code]";
            RevisedGSTPaymentType = "[Revised_GST_Payment_Type]";
            RevisedTaxableValue = "[Revised_Taxable_Value]";
            RevisedHSNSAC = "[Revised_HSN_SAC]";
            RevisedRate = "[Revised_Rate]";
            RevisedCess = "[Revised_Cess]";
            RevisedCGST = "[Revised_CGST]";
            RevisedSGST = "[Revised_SGST]";
            RevisedIGST = "[Revised_IGST]";
            RevisedTotalTax = "[Revised_Total_Tax]";
            RemarksforChangeinLiability = "[Remarks_for_Change_in_Liability]";
            GSTR1presentationRemark = "[GSTR_1_presentation_Remark]";

            /*UpdatedGSTIN = "[Updated_GSTIN]";
            UpdatedPOS = "[Updated_POS]";
            RevisedDocumentType = "[Revised_Document_Type]";
            RevisedUpdatedInvoiceNoDebitCreditNote = "[Revised_Updated_Invoice_No_Debit_Credit_Note]";
            RevisedUpdatedInvoiceDate = "[Revised_Updated_Invoice_Date]";
            ClientCode = "[Client_Code]";
            InvoiceNumber = "[Invoice_Number]";
            Month = "Month";
            Year = "Year";*/

            //DocumentType = "[Document_Type]" ;
            //BillingState = "[Billing_State]" ;
            //OriginalMonth = "[Original_Month]" ;
            //OriginalInvoiceAgainstCNDNReceiptNoAgaisntrefundno = "[Original_Invoice_Against_CN_DN_Receipt_No_Agaisnt_refund_no]" ;
            //dateAgaisntCNDNReceiptdateAgainstrefunddate = "[Original_Invoic_ date_Agaisnt_CN_DN_Receipt_date_Against_refund_date]" ;
            //InvoiceNoDebitCreditNote = "[Invoice_No_Debit_Credit_Note]" ;
            //InvoiceDate = "[Invoice_Date]" ;
            //ShippingBillNo = "[Shipping_Bill_No]" ;
            //ShippingBillDate = "[Shipping_Bill_Date]" ;
            //PortCode = "[Port_Code]" ;
            //PartyName = "[Party_Name]" ;
            //GSTIN = "[GSTIN]" ;
            //CategoryRegURDCompositionDealerUIN = "[Category_Reg_URD_Composition_Dealer_UIN]" ;
            //PlaceofSupply = "[Place_of_Supply]" ;
            //Type = "[Type_]" ;
            //Taxablevalue = "[Taxable_value]" ;
            //Rate = "[Rate_]" ;
            //Cess = "[Cess_]" ;
            //GSTPaymentType = "[GST_Payment_Type]" ;
            //TaxAmount = "[Tax_Amount]" ;
            //CGSTRs = "[CGST_Rs]" ;
            //SGSTUTGSTRs = "[SGST_UTGST_Rs]" ;
            //IGSTRs = "[IGST_Rs]" ;
            //TotalInvoiceValueRs = "[Total_Invoice_Value_Rs]" ;
            //UpdatedGSTIN = "[Updated_GSTIN]" ;
            //UpdatedPOS = "[Updated_POS]" ;
            //RevisedDocumentType = "[Revised_Document_Type]" ;
            //RevisedUpdatedInvoiceNoDebitCreditNote = "[Revised_Updated_Invoice_No_Debit_Credit_Note]" ;
            //RevisedUpdatedInvoiceDate = "[Revised_Updated_Invoice_Date]" ;
            //RevisedShippingBillNo = "[Revised_Shipping_Bill_No]" ;
            //RevisedShippingBillDate = "[Revised_Shipping_Bill_Date]" ;
            //RevisedPortCode = "[Revised_Port_Code]" ;
            //RevisedGSTPaymentType = "[Revised_GST_Payment_Type]" ;
            //RevisedTaxableValue = "[Revised_Taxable_Value]" ;
            //RevisedHSNSAC = "[Revised_HSN_SAC]" ;
            //RevisedRate = "[Revised_Rate]" ;
            //RevisedCess = "[Revised_Cess]" ;
            //CGST = "[CGST]" ;
            //SGST = "[SGST]" ;
            //IGST = "[IGST]" ;
            //TotalTax = "[Total_Tax]" ;
            //RemarksforChangeinLiability = "[Remarks_for_Change_in_Liability]" ;
            //GSTR1presentationRemark = "[GSTR_1_presentation_Remark]" ;
            //Month = "Month";
            //Year = "Year";
        }
    }
}
