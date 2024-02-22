using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly SalesContext _context;

        public RolRepository(SalesContext context)
        {
            _context = context;
        }

        public void Create(Rol NewRol)
        {
            try
            {
                var existUser = _context.Rol!.FirstOrDefault(r => r.Descripcion == NewRol.Descripcion);

                if (existUser is not null)
                {
                    throw new RolException("El Rol ya existe");
                }

                _context.Rol!.Add(NewRol);

                _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw ;
            }
        }

        public List<Rol> GetAllRoles()
        {
            try
            {
                return _context.Rol!.Where(r => !r.Eliminado).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Rol? GetRolById(int id)
        {
            try
            {
                return _context.Rol!.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(Rol RemoveRol)
        {
            try
            {
                var rol = GetRolById(RemoveRol.Id) ?? throw new RolException("El rol no existe");

                rol.Eliminado = true;

                rol.IdUsuarioElimino = RemoveRol.IdUsuarioElimino;

                rol.FechaElimino = RemoveRol.FechaElimino;

                _context.Rol!.Update(rol);

                _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Update(Rol UpdateRol)
        {
            try
            {
                var rol = GetRolById(UpdateRol.Id) ?? throw new RolException("El rol no existe");

                rol.Descripcion = UpdateRol.Descripcion;
                rol.FechaMod = DateTime.Now;
                rol.IdUsuarioMod = UpdateRol.IdUsuarioMod;

                _context.Rol!.Update(rol);
                _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
