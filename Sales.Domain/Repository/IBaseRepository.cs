namespace Sales.Domain.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetEntity(int id);
        List<TEntity> GetEntities();
        List<TEntity> FindAll(Func<TEntity, bool> filter);
        bool Exists(Func<TEntity, bool> filter);
        void Update(TEntity entity);
        void Save (TEntity entity);
        void Remuve(TEntity entity);
    }
}
