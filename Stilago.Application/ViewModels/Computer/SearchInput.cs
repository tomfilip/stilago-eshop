using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.Computer
{
    public class SearchInput: IInputDto
    {
        public string SearchTerm { get; set; }
        public Guid? BrandId { get; set; }

        public SortDirection SortDirection { get; set; }
        public SortBy SortBy { get; set; }

    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public enum SortBy
    {
        Model,
        Price,
        Brand
    }
}
