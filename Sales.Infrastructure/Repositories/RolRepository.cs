using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly SalesContext context;

        public RolRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Create(Rol NewRol)
        {
            try
            {
                var existUser = context.Rol!.FirstOrDefault(r => r.Descripcion == NewRol.Descripcion);

                if (existUser is not null)
                {
                    throw new RolException("El Rol ya existe");
                }

                context.Rol!.Add(NewRol);

                context.SaveChangesAsync();
            }
            catch (Exception exc)
            {

                throw new RolException("No se pudo crear el rol - " + exc.Message); ;
            }
        }

        public List<Rol> GetAllRoles()
        {
            try
            {
                return context.Rol!.Where(r => !r.Eliminado).ToList();
            }
            catch (Exception)
            {
               throw new RolException("No se pudo obtener los roles");
            }
        }

        public Rol? GetRolById(int id)
        {
            try
            {
                return context.Rol!.Find(id);
            }
            catch (Exception)
            {

                throw new RolException("No se pudo obtener el rol");
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

                context.Rol!.Update(rol);

                context.SaveChangesAsync();

            }
            catch (Exception exc)
            {

                throw new RolException("No se pudo eliminar el rol - " + exc.Message); ;
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

                context.Rol!.Update(rol);
                context.SaveChangesAsync();

            }
            catch (Exception exc)
            {

                throw new RolException("No se pudo actualizar el rol - " + exc.Message); ;
            }
        }
    }
}
