using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities
{
    public class ApplicationUserRole : IdentityUserRole<long>
    {
      
        public ApplicationUser User { get; set; }

      
        public ApplicationRole Role { get; set; }
    }
}
