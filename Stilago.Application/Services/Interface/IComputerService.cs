using Abp.Application.Services;
using Stilago.ViewModels.Computer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Services.Interface
{
    public interface IComputerService: IApplicationService
    {
        GetOutput Get(GetInput input);

        CreateEditOutput Create(CreateEditInput input);

        CreateEditOutput Update(CreateEditInput input);

        void Delete(DeleteInput input);
    }
}
