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
        public string Name { get; set; }
    }
}
