using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.Computer
{
    public class CreateEditOutput: IOutputDto
    {
        public Guid Id { get; set; }
    }
}
