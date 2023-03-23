using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.GLIncome
{
    public class GL_IncomeViewModel
    {
        public int Income_Booking_Resp_GL_ID { get; set; }
        public string? GL_Code { get; set; }
        public string? GL_Description { get; set; }
        public decimal Amount { get; set; }
    }
}
