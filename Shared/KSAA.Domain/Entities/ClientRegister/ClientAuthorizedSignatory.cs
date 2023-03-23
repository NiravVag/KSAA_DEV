using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.ClientRegister
{
    public class ClientAuthorizedSignatory : BaseEntity
    {
        public virtual string? FirstName { get; set; }
        public virtual string? MiddleName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? FatherFirstName { get; set; }
        public virtual string? FatherMiddleName { get; set; }
        public virtual string? FatherLastName { get; set; }
        public virtual DateTime BOD { get; set; }
        public virtual string? Gender { get; set; }
        public virtual string? DesignationStatus { get; set; }
        public virtual string? Mobile { get; set; }
        public virtual string? PhoneNoSTD { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? Address { get; set; }
        public virtual string? PAN { get; set; }
        public virtual string? DIN { get; set; }
        public virtual bool? Indian { get; set; }
        public virtual string? Photo { get; set; }
        public virtual string? CustomerCode { get; set; }
        public virtual string? CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
    }
}
