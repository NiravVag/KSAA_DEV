using KSAA.Domain.Entities.Master;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public ApplicationUser()
        {
            UserRoles = new HashSet<ApplicationUserRole>();
        }
        public virtual string? UserCode { get; set; }
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        [ForeignKey("UserTypeNavigation")]
        public virtual long UserType { get; set; }
        [ForeignKey("CompanyNavigation")]
        public virtual long Company { get; set; }
        public virtual IsActive IsActive { get; set; }
        public virtual string? IP { get; set; }
        public virtual string? BrowserCase { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual int? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual UserType UserTypeNavigation { get; set; }
        public virtual Company CompanyNavigation { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
    public enum IsActive
    {
        Active = 1,
        InActive = 2,
        Delete = 3
    }
}
