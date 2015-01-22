using Abp.Dependency;
using Stilago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Fundamentals.Interface
{
    public interface IUserInfo : ITransientDependency
    {
        User GetCurrentUser();
        Country GetCurrentCountry();
    }
}
