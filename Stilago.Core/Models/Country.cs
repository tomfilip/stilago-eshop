using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Models
{
    public class Country : Entity<Guid>
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Culture { get; set; }
    }
}
