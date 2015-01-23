using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Models
{
    public class BrandComputerRelationship: Entity<Guid>
    {
        public virtual Guid ComputerId { get; set; }

        public virtual Guid BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Computer Computer { get; set; }
    }
}
