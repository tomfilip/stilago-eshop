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
    public class ComputerInfo : AuditBase
    {
        [Required]
        [Range(0, long.MaxValue)]
        public virtual long Price { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid CountryId { get; set; }
        public virtual Guid ComputerId { get; set; }

        //Navigation Properties
        public virtual Country Country { get; set; }
        public virtual Computer Computer { get; set; }
    }
}
