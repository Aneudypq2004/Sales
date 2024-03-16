using Sales.Application.Contracts;
using Sales.Application.Core;
using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Context;

namespace Sales.Application.Service
{
    public class RolService : BaseService<Rol>, IRolService
    {
        public RolService(SalesContext context) : base(context)
        {
        }
    }
}
