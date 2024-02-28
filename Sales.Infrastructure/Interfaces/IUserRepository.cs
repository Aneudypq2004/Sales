using Sales.Domain.Entities.ModuloUsuario;
using Sales.Domain.Repository;

namespace Sales.Infrastructure.Interfaces
{
    public interface IUserRepository : IBaseRepository<Usuario>
    {
        Usuario? GetUserByEmail(string Email);
    }
}
