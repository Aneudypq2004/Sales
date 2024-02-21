using Sales.Domain.Entities.ModuloUsuario;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SalesContext _context;

        public UserRepository(SalesContext context)
        {
            _context = context;
        }

        public void Create(Usuario NewUser)
        {
            try
            {
                var existUser = _context.Usuarios!.FirstOrDefault(u => u.Correo == NewUser.Correo);

                if(existUser is not null)
                {
                    throw new UserException("Ya existe un usuario con este correo");
                }
                _context.Usuarios!.Add(NewUser);

                _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> GetAllUsers()
        {
            try
            {
                return _context.Usuarios!.Where(user => !user.Eliminado).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Usuario? GetUserById(int id)
        {
            try
            {
               return _context.Usuarios!.Find(id);
            }
            catch (Exception)
            {

                throw;
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

                _context.Usuarios!.Update(RemoveUser);

                _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
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
    
                _context.Usuarios!.Update(user);

                _context.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
