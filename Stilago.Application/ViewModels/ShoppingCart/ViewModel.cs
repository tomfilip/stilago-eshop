using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.ShoppingCart
{
    public class ViewModel: EntityDto<Guid>
    {
        public virtual Guid ComputerId { get; set; }
        public virtual Guid UserId { get; set; }
        [Range(0, int.MaxValue)]
        public virtual int Quantity { get; set; }
    }
}
