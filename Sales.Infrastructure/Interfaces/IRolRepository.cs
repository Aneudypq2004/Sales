using Sales.Domain.Entities.Usuario.Usuario;

namespace Sales.Infrastructure.Interfaces
{
    public interface IRolRepository
    {
        void Create(Rol NewRol);
        void Update(Rol UpdateRol);
        void Remove(Rol RemoveRol);
        List<Rol> GetAllRoles();
        Rol? GetRolById(int id);
    }
}
