using KSAA.Domain.Entities;
using KSAA.Domain.Entities.FunctionMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.Master
{
    public class FunctionModuleViewModel
    {
        public long Id { get; set; }
        public long FunctionId { get; set; }
        public string? FunctionName { get; set; }
        public string? ModuleName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
        public string? IP { get; set; }
        public string? BrowserCase { get; set; }
    }
}
