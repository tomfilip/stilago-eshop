using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Stilago.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Models
{
    public class AuditBase : Entity<Guid>, ISoftDelete, IAudit<Guid>
    {
        public virtual bool IsDeleted { get; set; }

        public virtual DateTimeOffset CreationTime { get; set; }

        public virtual DateTimeOffset LastModificationTime { get; set; }

        public virtual Guid CreatedById { get; set; }

        public virtual Guid ModifiedById { get; set; }
    }
}
