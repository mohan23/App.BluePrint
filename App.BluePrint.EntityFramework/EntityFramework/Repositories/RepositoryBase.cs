using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace App.BluePrint.EntityFramework.Repositories
{
    public abstract class RepositoryBase<TDbContext, TEntity, TPrimaryKey> : EfRepositoryBase<TDbContext, TEntity, TPrimaryKey>
        where TDbContext : AbpDbContext
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected RepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class RepositoryBase<TDbContext, TEntity> : RepositoryBase<TDbContext, TEntity, int>
        where TDbContext : AbpDbContext
        where TEntity : class, IEntity<int>
    {
        protected RepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
