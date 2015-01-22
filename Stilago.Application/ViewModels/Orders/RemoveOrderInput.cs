using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.Orders
{
    public class RemoveOrderInput
    {
       public IEnumerable<Guid> Ids { get; set; }
    }
}
