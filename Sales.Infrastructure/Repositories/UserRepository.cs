using Sales.Domain.Entities.ModuloUsuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SalesContext context;

        public UserRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Create(Usuario NewUser)
        {
            try
            {
                var existUser = context.Usuarios!.FirstOrDefault(u => u.Correo == NewUser.Correo);

                if(existUser is not null)
                {
                    throw new UserException("Ya existe un usuario con este correo");
                }

                context.Usuarios!.Add(NewUser);

                context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                throw new UserException("No se pudo crear el usuario - " + exc.Message);
            }
        }

        public List<Usuario> GetAllUsers()
        {
            try
            {
                return context.Usuarios!.Where(user => !user.Eliminado).ToList();
            }
            catch (Exception)
            {
                throw new UserException("No se pudo obtener los usuarios");
            }
        }

        public Usuario? GetUserById(int id)
        {
            try
            {
               return context.Usuarios!.Find(id);
            }
            catch (Exception exc)
            {

                throw new UserException("No se pudo obtener el usuario " + exc.Message);
            }
        }

        public void Remove(Usuario RemoveUser)
        {
            try
            {
                var user = GetUserById(RemoveUser.Id) ?? throw new UserException("El usuario no existe");

                user.Eliminado = true;

                user.IdUsuarioElimino = RemoveUser.IdUsuarioElimino;

                user.FechaElimino = RemoveUser.FechaElimino;

                context.Usuarios!.Update(user);

                context.SaveChangesAsync();

            }
            catch (Exception exc)
            {

                throw new UserException("No se pudo eliminar el usuario - " + exc.Message);
            }
        }

        public void Update(Usuario UpdateUser)
        {
            try
            {
                var user = GetUserById(UpdateUser.Id) ?? throw new UserException("El usuario no existe");

                user.Nombre = UpdateUser.Nombre;
                user.NombreFoto = UpdateUser.NombreFoto;
                user.FechaMod = DateTime.Now;
                user.IdUsuarioMod = UpdateUser.IdUsuarioMod;
    
                context.Usuarios!.Update(user);

                context.SaveChangesAsync();

            }
            catch (Exception exc)
            {

                throw new UserException("No se pudo actualizar el usuario - " + exc.Message);
            }
        }
    }
}
