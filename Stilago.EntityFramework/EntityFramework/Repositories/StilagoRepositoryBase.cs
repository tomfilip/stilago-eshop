using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Stilago.EntityFramework.Repositories
{
    public abstract class StilagoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<StilagoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected StilagoRepositoryBase(IDbContextProvider<StilagoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class StilagoRepositoryBase<TEntity> : StilagoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected StilagoRepositoryBase(IDbContextProvider<StilagoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
