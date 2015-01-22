using Stilago.Fundamentals.Interface;
using Stilago.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Abp.Dependency;

namespace Stilago.EntityFramework
{
    public class UserInfo: IUserInfo, ITransientDependency
    {
        public UserInfo(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        private readonly IUserRepository _UserRepository;

        public Models.User GetCurrentUser()
        {
            return _UserRepository
                .GetAll()
                .Include(x => x.Country)
                .FirstOrDefault();
        }

        public Models.Country GetCurrentCountry()
        {
            var user = GetCurrentUser();
            if (user != null)
            {
                return user.Country;
            }
            else
            {
                return null;
            }
        }
    }
}
