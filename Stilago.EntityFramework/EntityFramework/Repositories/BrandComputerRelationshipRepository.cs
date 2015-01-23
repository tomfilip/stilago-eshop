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
    public class BrandComputerRelationshipRepository : StilagoRepositoryBase<BrandComputerRelationship, Guid>, IBrandComputerRelationshipRepository
    {
        public BrandComputerRelationshipRepository(IDbContextProvider<StilagoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
            
        }
    }
}
