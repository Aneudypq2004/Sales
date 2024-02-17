
using Sales.Domain.Repository;

namespace Sales.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity: class
    {

    }
}
