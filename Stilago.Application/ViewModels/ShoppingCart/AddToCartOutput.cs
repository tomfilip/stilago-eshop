﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.ShoppingCart
{
    public class AddToCartOutput: IOutputDto
    {
        public Guid Id { get; set; }
    }
}
