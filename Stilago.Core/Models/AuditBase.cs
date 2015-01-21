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
    public class AuditBase : Entity<Guid>, ISoftDelete, IAudit<Guid, User>
    {
        public bool IsDeleted{ get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public DateTimeOffset LastModificationTime { get; set; }

        public Guid CreatedById { get; set; }

        public Guid ModifiedById { get; set; }

        public User CreatedBy { get; set; }

        public User ModifiedBy { get; set; }
    }
}
