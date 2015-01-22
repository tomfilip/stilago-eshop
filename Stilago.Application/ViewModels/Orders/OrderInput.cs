using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.Orders
{
    public class OrderInput: IInputDto
    {
        public Guid ShoppingCartId { get; set; }
    }
}
