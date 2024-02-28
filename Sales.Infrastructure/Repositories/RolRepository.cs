using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        private readonly SalesContext context;

        public RolRepository(SalesContext context) : base(context)
        {
            this.context = context;
        }

        public override void Save(Rol NewRol)
        {
            try
            {
                var existRol = Exists(r => r.Descripcion == NewRol.Descripcion);

                if (existRol)
                {
                    throw new RolException("El Rol ya existe");
                }

                context.Rol!.Add(NewRol);

                context.SaveChangesAsync();
            }
            catch (Exception exc)
            {

                throw new RolException(exc.Message); ;
            }
        }

        public override void Remove(Rol RemoveRol)
        {
            try
            {
                var rol = GetEntity(RemoveRol.Id) ?? throw new RolException("El rol no existe");

                rol.Eliminado = true;

                rol.IdUsuarioElimino = RemoveRol.IdUsuarioElimino;

                rol.FechaElimino = RemoveRol.FechaElimino;

                context.Rol!.Update(rol);

                context.SaveChangesAsync();

            }
            catch (Exception exc)
            {

                throw new RolException(exc.Message); ;
            }

        }

        public override void Update(Rol UpdateRol)
        {
            try
            {
                var rol = GetEntity(UpdateRol.Id) ?? throw new RolException("El rol no existe");

                rol.Descripcion = UpdateRol.Descripcion;
                rol.FechaMod = DateTime.Now;
                rol.IdUsuarioMod = UpdateRol.IdUsuarioMod;

                context.Rol!.Update(rol);
                context.SaveChangesAsync();

            }
            catch (Exception exc)
            {

                throw new RolException(exc.Message); ;
            }
        }

        public override List<Rol> GetEntities()
        {
            try
            {
                return FindAll(r => !r.Eliminado);
            }
            catch (Exception)
            {
               throw new RolException("No se pudo obtener los roles");
            }
        }

        public override Rol? GetEntity(int id)
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
    }
}
