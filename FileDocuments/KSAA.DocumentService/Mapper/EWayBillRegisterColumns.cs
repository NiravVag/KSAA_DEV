using KSAA.DocumentService.Interfaces;

namespace KSAA.DocumentService.Mapper
{
    public class EWayBillRegisterColumns : IFieldBase
    {
        public string EWBNo = "";
        public string EWBDate = "";
        public string SupplyType = "";
        public string DocNo = "";
        public string DocDate = "";
        public string OtherPartyGSTIN = "";
        public string TransporterDetails = "";
        public string FromGSTINInfo = "";
        public string TOGSTINInfo = "";
        public string Status = "";
        public string NoOfItems = "";
        public string MainHSNCode = "";
        public string MainHSNDesc = "";
        public string AssessableValue = "";
        public string SGST = "";
        public string CGST = "";
        public string IGST = "";
        public string CESS = "";
        public string CESSNonAdvol = "";
        public string OtherValue = "";
        public string TotalInvoice = "";
        public string ValidTillDate = "";
        public string ModeOfGeneration = "";
        public string CancelledBy = "";
        public string CancelledDate = "";
        public string Month;
        public string Year;
        public EWayBillRegisterColumns() 
        {
            //EWBNo = "EWB No";
            //EWBDate = "EWB Date";
            //SupplyType = "Supply Type";
            //DocNo = "Doc No";
            //DocDate = "Doc Date";
            //OtherPartyGSTIN = "Other Party GSTIN";
            //TransporterDetails = "Transporter Details";
            //FromGSTINInfo = "From GSTIN Info";
            //TOGSTINInfo = "TO GSTIN Info";
            //Status = "status";
            //NoOfItems = "No of Items";
            //MainHSNCode = "Main HSN Code";
            //MainHSNDesc = "Main HSN Desc";
            //AssessableValue = "Assessable Value";
            //SGST = "SGST Value";
            //CGST = "CGST Value";
            //IGST = "IGST Value";
            //CESS = "CESS Value";
            //CESSNonAdvol = "CESS Non Advol Value";
            //OtherValue = "Other Value";
            //TotalInvoice = "Total Invoice Value";
            //ValidTillDate = "Valid Till Date";
            //ModeOfGeneration = "Mode of Generation";
            //CancelledBy = "Cancelled By";
            //CancelledDate = "Cancelled Date";
            //Month = "Month";
            //Year = "Year";

            EWBNo = "EWB_No";
            EWBDate = "EWB_Date";
            SupplyType = "Supply_Type";
            DocNo = "Doc_No";
            DocDate = "Doc_Date";
            OtherPartyGSTIN = "Other_Party_GSTIN";
            TransporterDetails = "Transporter_Details";
            FromGSTINInfo = "From_GSTIN_Info";
            TOGSTINInfo = "TO_GSTIN_Info";
            Status = "status";
            NoOfItems = "No_of_Items";
            MainHSNCode = "Main_HSN_Code";
            MainHSNDesc = "Main_HSN_Desc";
            AssessableValue = "Assessable_Value";
            SGST = "SGST_Value";
            CGST = "CGST_Value";
            IGST = "IGST_Value";
            CESS = "CESS_Value";
            CESSNonAdvol = "CESS_Non_Advol_Value";
            OtherValue = "Other_Value";
            TotalInvoice = "Total_Invoice_Value";
            ValidTillDate = "Valid_Till_Date";
            ModeOfGeneration = "Mode_of_Generation";
            CancelledBy = "Cancelled_By";
            CancelledDate = "Cancelled_Date";
            Month = "Month";
            Year = "Year";
        }
    }
}
