using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities
{
    public class UserStatuses : BaseEntity
    {
        public virtual string? StatusDescription { get; set; }
        public virtual string? StatusValue { get; set; }
    }
}
