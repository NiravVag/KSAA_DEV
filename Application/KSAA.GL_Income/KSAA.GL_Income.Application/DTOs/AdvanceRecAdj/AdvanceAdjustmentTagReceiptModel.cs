using KSAA.GL_Income.Application.DTOs.OutputRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.AdvanceRecAdj
{
    public class AdvanceAdjustmentTagReceiptModel
    {
        //public List<OutputRegisterViewModel> getSLRegisterData { get; set; }
        //public AdvanceAdjustmentViewModel getAdvanceAdjustment { get; set; }

        public long SLRegisterId { get; set; }
        public long AdvancedReceivedID { get; set; }
        //public string? ClientCode { get; set; }
        //public string? EmployeeCode { get; set; }
        //public string? InvoiceNumberSL { get; set; }
        public string? InvoiceAmount { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? AmendmentInvoiceAmount { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
}
