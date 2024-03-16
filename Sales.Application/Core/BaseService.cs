using Sales.Domain.Service;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;

namespace Sales.Application.Core
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity: class
    {
        BaseRepository<TEntity> repository;
        public BaseService(SalesContext context)
        {
            this.repository = new(context);
            
        }
        public virtual ServicesResult<IEnumerable<TEntity>> GetAll()
        {
            ServicesResult<IEnumerable<TEntity>> result = new();

            result.Data = repository.GetEntities();

            return result;

        }

        public virtual ServicesResult<TEntity> GetById(dynamic id)
        {
            ServicesResult<TEntity> result = new();

            result.Data = repository.GetEntity(id);

            return result;
        }

        public virtual ServicesResult<int> Remove(TEntity entity)
        {
            ServicesResult<int> result = new();

            repository.Remove(entity);

            return result;
        }

        public virtual ServicesResult<TEntity> Save(TEntity entity)
        {
            ServicesResult<TEntity> result = new();

            repository.Save(entity);

            result.Data = null;

            return result;
        }

        public virtual ServicesResult<int> Update(TEntity entity)
        {
            ServicesResult<int> result = new();

            repository.Update(entity);

            return result;
        }
    }
}
