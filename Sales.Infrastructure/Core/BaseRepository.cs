using Sales.Domain.Repository;

namespace Sales.Infrastructure.Core
{
    public class BaseRepository<Tentity> where Tentity : class, IBaseRepository<Tentity>
    {
    }
}
