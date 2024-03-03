using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.User;
using Sales.Api.Models;
using Sales.Domain.Entities.ModuloUsuario;
using Sales.Infrastructure.Interfaces;


namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet("GetUsers")]
        public ActionResult Get()
        {
            var result = repository.GetEntities().Select( e => new UserGetModel()
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Correo = e.Correo,
                Telefono = e.Telefono,
                IdRol = e.IdRol
            });

            return Ok(result);
        }

        [HttpGet("GetUserById")]
        public ActionResult Get(int id)
        {
            var usuario = repository.GetEntity(id);

            if (usuario is null) return BadRequest();

            var usuarioGetModel = new UserGetModel()
            {
                Id = id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                IdRol = usuario.IdRol
            };

            return Ok(usuarioGetModel);
        }

        [HttpPost("SaveUser")]
        public ActionResult Post([FromBody] UserAddDto user)
        {
            repository.Save(new Usuario()
            {
                
                Nombre = user.Nombre,
                Correo = user.Correo,
                Telefono = user.Telefono,
                Clave = user.Clave,
                IdUsuarioCreacion = user.IdUsuario,
                FechaRegistro = user.ChangeTime

             });

            return Ok("Usuario registrado correctamente");
        }

        [HttpPost("UpdateUser")]
        public ActionResult Put([FromBody] UserUpdateDto user)
        {
            repository.Update(new Usuario()
            {
                Id = user.Id,
                Nombre = user.Nombre,
                Correo = user.Correo,
                Telefono = user.Telefono,
                Clave = user.Clave,
                IdUsuarioMod = user.IdUsuario,
                FechaMod = user.ChangeTime
            });

            return Ok("Usuario actualizado correctaente");
        }

        [HttpPost("DeleteUser")]
        public ActionResult Delete([FromBody] UserDeleteDto user)
        {
            repository.Remove(new Usuario()
            {
                Id = user.Id,
                FechaElimino = user.ChangeTime,
                IdUsuarioElimino = user.IdUsuario
            });

            return Ok("Usuario eliminado correctamente");
        }
    }
}
