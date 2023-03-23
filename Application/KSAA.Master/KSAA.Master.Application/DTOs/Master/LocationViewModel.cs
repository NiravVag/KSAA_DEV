using KSAA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Master.Application.DTOs.Master
{
    public class LocationViewModel
    {
        public long Id { get; set; }
        public string? Location_Code { get; set; }
        public string? Address { get; set; }
        public string? GSTRegistrationNo { get; set; }
        public string? TypeOfUnit { get; set; }
        public string? ProductsManufactured { get; set; }
        public string? ProductsTraded { get; set; }
        public string? TypeOfServicesProvided { get; set; }
        public string? IP { get; set; }
        public string? BrowserCase { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }

    }
}