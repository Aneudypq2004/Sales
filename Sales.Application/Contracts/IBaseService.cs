
using Sales.Application.Core;

namespace Sales.Domain.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {

        ServicesResult<IEnumerable<TEntity>> GetAll();

        ServicesResult<TEntity> GetById(dynamic id);

        ServicesResult<TEntity> Save(TEntity entity);

        ServicesResult<int> Remove(TEntity entity);

        ServicesResult<int> Update(TEntity entity);
    }
}
