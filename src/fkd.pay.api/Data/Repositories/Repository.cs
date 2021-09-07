using fkd.pay.api.Data.Context;
using fkd.pay.api.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace fkd.pay.api.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity: Entity
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = applicationDbContext.Set<TEntity>();
        }
        
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _applicationDbContext;
            }
        }

        public void Add(TEntity obj)
        {
            _applicationDbContext.Add(obj);
        }
    }
}