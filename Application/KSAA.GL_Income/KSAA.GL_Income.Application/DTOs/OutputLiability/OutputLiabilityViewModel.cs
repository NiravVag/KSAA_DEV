using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.GL_Income.Application.DTOs.OutputLiability
{
    public class OutputLiabilityViewModel
    {
        public int Income_Booking_Resp_GL_ID { get; set; }
        public string? GL_Code { get; set; }
        public string? GL_Description { get; set; }
        public decimal Amount { get; set; }
    }
}
