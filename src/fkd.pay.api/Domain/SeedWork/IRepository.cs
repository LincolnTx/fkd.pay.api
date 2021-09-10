namespace fkd.pay.api.Domain.SeedWork
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        void Add(TEntity obj);
    }
}