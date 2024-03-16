using Sales.Application.Contracts;
using Sales.Application.Core;
using Sales.Domain.Entities.ModuloUsuario;
using Sales.Infrastructure.Context;

namespace Sales.Application.Service
{
    public class UserService : BaseService<Usuario>, IUserService
    {
        public UserService(SalesContext context) : base(context)
        {
        }
    }
}
