using Sales.Application.Contracts;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.core;

namespace Sales.Application.Core
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        BaseRepository<TEntity> repository;
        public BaseService(SalesContext context)
        {
            this.repository = new(context);
        }
        public virtual ServiceResult<IEnumerable<TEntity>> GetAll()
        {
            ServiceResult<IEnumerable<TEntity>> result = new();

            result.Data = repository.GetEntities();

            return result;

        }

        public virtual ServiceResult<TEntity> GetById(dynamic id)
        {
            ServiceResult<TEntity> result = new();

            result.Data = repository.GetEntity(id);

            return result;
        }

        public virtual ServiceResult<int> Remuve(TEntity entity)
        {
            ServiceResult<int> result = new();

            repository.Remuve(entity);

            return result;
        }

        public virtual ServiceResult<TEntity> Save(TEntity entity)
        {
            ServiceResult<TEntity> result = new();

            repository.Save(entity);

            result.Data = null;

            return result;
        }

        public virtual ServiceResult<int> Update(TEntity entity)
        {
            ServiceResult<int> result = new();

            repository.Update(entity);

            return result;
        }
    }
}
