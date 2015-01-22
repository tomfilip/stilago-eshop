using Abp.EntityFramework;
using Stilago.Models;
using Stilago.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stilago.EntityFramework.Repositories
{
    public class CountryRepository: StilagoRepositoryBase<Country, Guid>, ICountryRepository
    {
        public CountryRepository(IDbContextProvider<StilagoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
