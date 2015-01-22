using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.Brand
{
    public class GetAllOutput: IOutputDto
    {
        public IEnumerable<ListViewModel> Brands { get; set; }
    }
}
