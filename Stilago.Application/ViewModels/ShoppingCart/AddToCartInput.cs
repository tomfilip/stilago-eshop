using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.ShoppingCart
{
    public class AddToCartInput: IInputDto
    {
        public virtual Guid ComputerId { get; set; }
        [Range(0, int.MaxValue)]
        public virtual int Quantity { get; set; }
    }
}
