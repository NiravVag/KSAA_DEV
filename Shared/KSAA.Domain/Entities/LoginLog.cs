using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities
{
    public partial class LoginLog
    {
        public virtual Guid LoginLogId { get; set; }
        public virtual DateTime? LoginDate { get; set; }
        public virtual bool? LoginSuccess { get; set; }
    }
}
