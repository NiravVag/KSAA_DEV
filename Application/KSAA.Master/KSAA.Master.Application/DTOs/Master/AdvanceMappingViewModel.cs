using KSAA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.Master
{
	public class AdvanceMappingViewModel
	{
        public long Id { get; set; }
        public string? CustomerCode { get; set; }
        public string? AdvanceMappingCode { get; set; }
        public string? GLAdvanceName { get; set; }
        public string? GLAdvanceCode { get; set; }
        //public string? Upload { get; set; }
        public string? LedgerMapping { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
        public string? IP { get; set; }
        public string? BrowserCase { get; set; }
    }
}