using KSAA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.DTOs.ClientRegister.ListDTOs
{
    public class ClientAuthorizedSignatoryListModel
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FatherFirstName { get; set; }
        public string? FatherMiddleName { get; set; }
        public string? FatherLastName { get; set; }
        public string BOD { get; set; }
        public string? Gender { get; set; }
        public string? DesignationStatus { get; set; }
        public string? Mobile { get; set; }
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
