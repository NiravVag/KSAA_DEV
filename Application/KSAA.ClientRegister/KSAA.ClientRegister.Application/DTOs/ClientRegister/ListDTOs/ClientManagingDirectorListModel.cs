using KSAA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs
{
    public class ClientManagingDirectorListModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? FatherName { get; set; }
        public string BOD { get; set; }
        public string? DesignationStatus { get; set; }
        public string? MobileNumber { get; set; }
        public string? PhoneNoSTD { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PAN { get; set; }
        public string? DIN { get; set; }
        public bool? Indian { get; set; }
        public string? Photo { get; set; }
        public string? CustomerCode { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public IsActive IsActive { get; set; }
        public string? IP { get; set; }
        public string? BrowserCase { get; set; }
    }
}
