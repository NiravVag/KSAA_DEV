using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities.ClientRegister
{
    public class ClientRegistration : BaseEntity
    {
        public virtual string? RegistrationType { get; set; }
        public virtual string? RegistrationNumber { get; set; }
        public virtual DateTime RegistrationDate { get; set; }
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
