using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Models
{
    public class Brand : AuditBase
    {
        public virtual string Name { get; set; }
        public virtual Guid CountryId { get; set; }

        //Navigation Properties
        public virtual Country Country { get; set; }

        public virtual ICollection<BrandComputerRelationship> ComputerRelationships { get; set; }
    }
}
