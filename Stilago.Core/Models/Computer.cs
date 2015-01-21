using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Models
{
    public class Computer : AuditBase
    {
        [MaxLength(15)]
        [Required]
        public virtual string Model { get; set; }
        [Required]
        public virtual Guid BrandId { get; set; }

        /// <summary>
        /// Disk capacity in MB
        /// </summary>
        [Required]
        public virtual long DiskCapacity { get; set; }

        //Navigation Properties
        [Required]
        public virtual Brand Brand { get; set; }
    }
}
