namespace Sales.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity? GetEntity(int Id);
        List<TEntity> FindAll(Func<TEntity, bool>filter);

        bool Exists (Func<TEntity, bool> filter);

        List<TEntity> GetEntities();

        void Remove(TEntity entity);

        void Update(TEntity entity);

        void Save(TEntity entity);


    }
}
