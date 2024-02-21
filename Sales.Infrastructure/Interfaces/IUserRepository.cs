using Sales.Domain.Entities.ModuloUsuario;

namespace Sales.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        void Create(Usuario NewUser);
        void Update(Usuario UpdateUser);
        void Remove(Usuario RemoveUser);
        List<Usuario> GetAllUsers();
        Usuario? GetUserById(int id);
    }
}
