using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.OutputLiability
{
    public class OutputRegisterListModel
    {
        //public List<OutputRegisterListModel> outputRegisterList { get; set; }
        public long Id { get; set; }
        public string? Document_Type { get; set; }
        public string? Invoice_Number { get; set; }
        public string? Invoice_Date { get; set; }
        public string? E_Invoice_No { get; set; }
        public string? E_Invoice_Date { get; set; }
        public string? E_Invoice_Total_Amount { get; set; }
        public string? E_Invoice_Tax_Amount { get; set; }
        public string? E_Invoice_Amount_Different { get; set; }
        public string? E_Invoice_Tax_Different { get; set; }
        public string? Shipping_Bill_No { get; set; }
        public DateTime? Shipping_Bill_Date { get; set; }
        public string? HSN_Code { get; set; }
        public string? Quantity { get; set; }
        public string? Unique_Quantity_Code { get; set; }
        public string? Description { get; set; }
        public string? Party_Name { get; set; }
        public string? GSTIN { get; set; }
        public string? Reverse_Charge { get; set; }
        public string? Place_Of_Supply_State_Name { get; set; }
        public string? Exchange_Rate_As_Per_Notifications { get; set; }
        public string? Exchange_Rate_As_Per_Shipping_Bill { get; set; }
        public decimal Taxable_Value { get; set; }
        public string? Rate { get; set; }
        public decimal Total_Tax { get; set; }
        public decimal Central_Tax { get; set; }
        public decimal State_UT_Tax { get; set; }
        public decimal Integrated_Tax { get; set; }
        public decimal Cess_Amount { get; set; }
        public decimal Total_Invoice_Value_Rs { get; set; }
        public string? Vehicle_No { get; set; }
        public string? E_Way_Bill_No { get; set; }
        public string? Dispatch_Location_Code { get; set; }
        public string? Port_Code { get; set; }
        public string? Voucher_No { get; set; }
        public string? Accounting_Date { get; set; }
        public string? Location_Code { get; set; }
        public string? GL_Code { get; set; }
        public string? E_Invoice_No_2 { get; set; }
        public string? E_Invoice_Date_2 { get; set; }
        public string? E_Way_Bill_No_2 { get; set; }
        public string? E_Way_Date_2 { get; set; }
        public string? Remarks { get; set; }
        public string? Action { get; set; }

        public string? Invoice_Number_LL { get; set; }
        public decimal CGSTLL { get; set; }
        public decimal SGSTLL { get; set; }
        public decimal IGSTLL { get; set; }
        public decimal CessLL { get; set; }

        public decimal Diffarances_CGST_SLLL { get; set; }
        public decimal Difference_SGST_SLLL { get; set; }
        public decimal Difference_IGST_SLLL { get; set; }
        public decimal Difference_Cess_SLLL { get; set; }
    }
}
