using Sales.Domain.Entities.ModuloUsuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Services;

namespace Sales.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<Usuario>,  IUserRepository
    {
        private readonly SalesContext context;
        private readonly LoggerService<UserRepository> logger;

        public UserRepository(SalesContext context, LoggerService<UserRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override void Save(Usuario NewUser)
        {
            try
            {
                var existUser = Exists(u => u.Correo == NewUser.Correo);

                if(existUser)
                {
                    throw new UserException("Ya existe un usuario con este correo");
                }

                context.Usuario!.Add(NewUser);

                var result = context.SaveChanges();

                Console.WriteLine(result);

            }
            catch (Exception exc)
            {
                throw new UserException("No se pudo crear el usuario - " + exc.Message);
            }
        }

        public override List<Usuario> GetEntities()
        {
            try
            {
                return context.Usuario!.ToList();
            }
            catch (Exception)
            {
                throw new UserException("No se pudo obtener el usuario");
            }
        }

        public Usuario? GetUserByEmail(string Email)
        {
            try
            {
                return context.Usuario!.FirstOrDefault(e => e.Correo!.Equals(Email));

            }
            catch (Exception)
            {

                throw new UserException("No se pudo obtener el usuario");

            }
        }

        public override Usuario? GetEntity(int id)
        {
            try
            {
                return context.Usuario!.Find(id);
            }
            catch (Exception exc)
            {

                throw new UserException("No se pudo obtener el usuario " + exc.Message);
            }
        }

        public override void Remove(Usuario RemoveUser)
        {
            try
            {
                var user = GetEntity(RemoveUser.Id) ?? throw new UserException("El usuario no existe");

                user.Eliminado = true;

                user.IdUsuarioElimino = RemoveUser.IdUsuarioElimino;

                user.FechaElimino = RemoveUser.FechaElimino;

                context.Usuario!.Update(user);

                context.SaveChanges();

            }
            catch (Exception exc)
            {

                throw new UserException("No se pudo eliminar el usuario - " + exc.Message);
            }
        }

        public override void Update(Usuario UpdateUser)
        {
            try
            {
                var user = GetEntity(UpdateUser.Id) ?? throw new UserException("El usuario no existe");

                user.Nombre = UpdateUser.Nombre;
                user.NombreFoto = UpdateUser.NombreFoto;
                user.FechaMod = DateTime.Now;
                user.IdUsuarioMod = UpdateUser.IdUsuarioMod;
    
                context.Usuario!.Update(user);

                context.SaveChanges();

            }
            catch (Exception exc)
            {

                throw new UserException("No se pudo actualizar el usuario - " + exc.Message);
            }
        }
    }
}
