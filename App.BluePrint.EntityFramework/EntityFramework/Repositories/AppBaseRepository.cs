using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace App.BluePrint.EntityFramework.Repositories
{
    public abstract class AppBaseRepository<TEntity, TPrimaryKey> : EfRepositoryBase<AppDbContext, TEntity, TPrimaryKey>
       where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AppBaseRepository(IDbContextProvider<AppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class AppBaseRepository<TEntity> : AppBaseRepository<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AppBaseRepository(IDbContextProvider<AppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
