using Abp.Domain.Repositories;
using Stilago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.Repository
{
    public interface IUserRepository: IRepository<User, Guid>
    {
    }
}
