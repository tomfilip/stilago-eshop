using Abp.Application.Services;
using Stilago.ViewModels.Brand;
using Stilago.ViewModels.Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Services.Interface
{
    public interface ISearchService: IApplicationService
    {
        SearchOutput Autocomplete(SearchInput input);
        SearchOutput Search(SearchInput input);
        GetAllOutput GetAllBrands();
    }
}
