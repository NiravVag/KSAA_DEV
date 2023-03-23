using KSAA.DocumentService.Interfaces;

namespace KSAA.DocumentService.Mapper
{
    public class ITCRegisterColumns : IFieldBase
    {
        public string GLCode = "";
        public string PlantCode = "";
        public string ReturnPeriod = "";
        public string DocumentType = "";
        public string DocumentNumber = "";
        public string DocumentDate = "";
        public string SupplierGSTIN = "";
        public string SupplierName = "";
        public string SupplierCode = "";
        public string PlaceofSupply = "";
        public string BillofEntryNumber = "";
        public string BillofEntryDate = "";
        public string HSNorSAC = "";
        public string ItemCode = "";
        public string ItemDescription = "";
        public string UnitofMeasurement = "";
        public string Quantity = "";
        public string TaxableValue = "";
        public string IGST = "";
        public string CGST = "";
        public string SGST_UTGST = "";
        public string TotalTax = "";
        public string Cess = "";
        public string InvoiceValue = "";
        public string ReverseChargeFlag = "";
        public string WhetherCapitalised = "";
        public string PurchaseVoucherNumber = "";
        public string PurchaseVoucherDate = "";
        public string PaymentVoucher = "";
        public string PaymentDate = "";
        public string EligibilityCriteria = "";
        public string TypeofITC = "";
        public string Remarks = "";

        public ITCRegisterColumns() 
        {
            GLCode = "GL_Code";
            PlantCode = "Plant_Code";
            ReturnPeriod = "Return_Period";
            DocumentType = "Document_Type";
            DocumentNumber = "Document_Number";
            DocumentDate = "Document_Date";
            SupplierGSTIN = "Supplier_GSTIN";
            SupplierName = "Supplier_Name";
            SupplierCode = "Supplier_Code";
            PlaceofSupply = "Place_of_Supply";
            BillofEntryNumber = "Bill_of_Entry_Number";
            BillofEntryDate = "Bill_of_Entry_Date";
            HSNorSAC = "HSN_or_SAC";
            ItemCode = "Item_Code";
            ItemDescription = "Item_Description";
            UnitofMeasurement = "Unit_of_Measurement";
            Quantity = "Quantity";
            TaxableValue = "Taxable_Value";
            IGST = "IGST";
            CGST = "CGST";
            SGST_UTGST = "SGST_UTGST";
            TotalTax = "Total_Tax";
            Cess = "Cess";
            InvoiceValue = "Invoice_Value";
            ReverseChargeFlag = "Reverse_Charge_Flag";
            WhetherCapitalised = "Whether_Capitalised";
            PurchaseVoucherNumber = "Purchase_Voucher_Number";
            PurchaseVoucherDate = "Purchase_Voucher_Date";
            PaymentVoucher = "Payment_Voucher";
            PaymentDate = "Payment_Date";
            EligibilityCriteria = "Eligibility_Criteria";
            TypeofITC = "Type_of_ITC";
            Remarks = "Remarks";

        }
    }
}
