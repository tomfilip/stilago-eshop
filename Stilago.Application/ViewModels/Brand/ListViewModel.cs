using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.Brand
{
    public class ListViewModel: EntityDto<Guid>
    {
        public virtual string Name { get; set; }
        public virtual Guid CountryId { get; set; }
        public virtual Guid ComputerId { get; set; }
    }
}
