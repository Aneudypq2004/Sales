using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Services;

namespace Sales.Infrastructure.Repositories
{
    public class RolRepository : BaseRepository<Rol>, IRolRepository
    {
        private readonly SalesContext context;
        private readonly LoggerService<UserRepository> logger;

        public RolRepository(SalesContext context, LoggerService<UserRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override void Save(Rol NewRol)
        {
            try
            {
                //var existRol = Exists(r => r.Descripcion == NewRol.Descripcion);

                //if (existRol)
                //{
                //    throw new RolException("El Rol ya existe");
                //}

                context.Rol!.Add(NewRol);

                context.SaveChanges();
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

                context.SaveChanges();

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
                context.SaveChanges();

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
                return context.Rol!.ToList();
            }
            catch (Exception e)
            {
               throw new RolException("No se pudo obtener los roles " + e.Message);
            }
        }

        public override Rol? GetEntity(int id)
        {
            try
            {
                return context.Rol!.Find(id);
            }
            catch (Exception e)
            {

                throw new RolException("No se pudo obtener el rol" + e.Message );
            }
        }
    }
}
