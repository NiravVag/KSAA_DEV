using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.GL_Income
{
    public class OutputRegisterModel : BaseEntity
    {
        public virtual string? Document_Type { get; set; }
        public virtual string? Invoice_Number { get; set; }
        public virtual string? Invoice_Date { get; set; }
        public virtual string? E_Invoice_No { get; set; }
        public virtual string? E_Invoice_Date { get; set; }
        public virtual string? E_Invoice_Total_Amount { get; set; }
        public virtual string? E_Invoice_Tax_Amount { get; set; }
        public virtual string? E_Invoice_Amount_Different { get; set; }
        public virtual string? E_Invoice_Tax_Different { get; set; }
        public virtual string? Shipping_Bill_No { get; set; }
        public virtual DateTime? Shipping_Bill_Date { get; set; }
        public virtual string? HSN_Code { get; set; }
        public virtual string? Quantity { get; set; }
        public virtual string? Unique_Quantity_Code { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? Party_Name { get; set; }
        public virtual string? GSTIN { get; set; }
        public virtual string? Reverse_Charge { get; set; }
        public virtual string? Place_Of_Supply_State_Name { get; set; }
        public virtual string? Exchange_Rate_As_Per_Notifications { get; set; }
        public virtual string? Exchange_Rate_As_Per_Shipping_Bill { get; set; }
        public virtual decimal Taxable_Value { get; set; }
        public virtual string? Rate { get; set; }
        public virtual decimal Total_Tax { get; set; }
        public virtual decimal Central_Tax { get; set; }
        public virtual decimal State_UT_Tax { get; set; }
        public virtual decimal Integrated_Tax { get; set; }
        public virtual decimal Cess_Amount { get; set; }
        public virtual double Total_Invoice_Value_Rs { get; set; }
        public virtual string? Vehicle_No { get; set; }
        public virtual string? E_Way_Bill_No { get; set; }
        public virtual string? Dispatch_Location_Code { get; set; }
        public virtual string? Port_Code { get; set; }
        public virtual string? Voucher_No { get; set; }
        public virtual string? Accounting_Date { get; set; }
        public virtual string? Location_Code { get; set; }
        public virtual string? GL_Code { get; set; }
        public virtual string? E_Invoice_No_2 { get; set; }
        public virtual string? E_Invoice_Date_2 { get; set; }
        public virtual string? E_Way_Bill_No_2 { get; set; }
        public virtual string? E_Way_Date_2 { get; set; }
        public virtual string? Remarks { get; set; }
        public virtual string? Action { get; set; }
    }
}
