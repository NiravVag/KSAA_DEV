using KSAA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.Master
{
    public class VendorCodeViewModel
    {
        public long Id { get; set; }
        public string? Vendor_Code { get; set; }
        public string? GSTN { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? IP { get; set; }
        public string? BrowserCase { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
    }

}