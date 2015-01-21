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
    public class Country : AuditBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Culture { get; set; }
    }
}
