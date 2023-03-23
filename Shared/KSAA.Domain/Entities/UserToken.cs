using KSAA.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.Domain.Entities
{
    public class UserToken : BaseEntity
    {
        public virtual Guid UserTokenId { get; set; }
        public virtual string? Token { get; set; }
        public virtual string? JwtToken { get; set; }
        public virtual DateTime Expires { get; set; }
        public virtual bool IsExpired => DateTime.UtcNow >= Expires;
        public virtual string? ReplacedByToken { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? RevokedDate { get; set; }
        //public virtual string CreatedByIp { get; set; }
        //public virtual string RevokedByIp { get; set; }
        public virtual bool IsActive => RevokedDate == null && !IsExpired;
        public virtual long UserId { get; set; }
    }
}
