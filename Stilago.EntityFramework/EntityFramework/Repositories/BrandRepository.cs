using Abp.EntityFramework;
using Stilago.Models;
using Stilago.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Stilago.EntityFramework.Repositories
{
    public class BrandRepository: StilagoRepositoryBase<Brand, Guid>, IBrandRepository
    {
        public BrandRepository(IDbContextProvider<StilagoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            
        }
    }
}
