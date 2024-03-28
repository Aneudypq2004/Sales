using Sales.Application.Core;

namespace Sales.Application.Contracts
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        ServiceResult<IEnumerable<TEntity>> GetAll();
        ServiceResult<TEntity> GetById(dynamic id);
        ServiceResult<TEntity> Save(TEntity entity);
        ServiceResult<int> Remuve(TEntity entity);
        ServiceResult<int> Update(TEntity entity);
    }
}
