using KSAA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.Master
{
    public class FunctionViewModel
    {
        public long Id { get; set; }
        public string? FunctionName { get; set; }
        public string? FunctionCode { get; set; }
        public string? ClientCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
        public string? IP { get; set; }
        public string? BrowserCase { get; set; }
    }
}
