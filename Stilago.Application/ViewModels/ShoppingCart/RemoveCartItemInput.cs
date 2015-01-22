using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.ViewModels.ShoppingCart
{
    public class RemoveCartItemInput
    {
        IEnumerable<Guid> Ids { get; set; }
    }
}
