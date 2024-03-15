
using Sales.Domain.Entities;
using Sales.Domain.Entities.negocios;
using Sales.Domain.Repository;

namespace Sales.Infrastructure.Interface
{
    public interface INegocioRepository : IBaseRepository<Negocio>
    {
    }
}
