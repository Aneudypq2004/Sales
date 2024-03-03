using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Rol;
using Sales.Api.Models;
using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Interfaces;


namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository repository;

        public RolController(IRolRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet("GetRoles")]
        public ActionResult Get()
        {
            var result = repository.GetEntities().Select(e => new RolGetModel()
            {
                Descripcion = e.Descripcion
            });

            return Ok(result);
        }

        [HttpGet("GetRolById")]
        public ActionResult Get(int id)
        {
            var rol = repository.GetEntity(id);

            if (rol is null) return BadRequest();

            var rolGetModel = new RolGetModel()
            {
                Descripcion = rol.Descripcion
            };

            return Ok(rolGetModel);
        }

        [HttpPost("SaveRol")]
        public ActionResult Post([FromBody] RolAddDto rol)
        {
            repository.Save(new Rol()
            {
                Descripcion = rol.Descripcion,
                FechaRegistro = rol.ChangeTime,
                IdUsuarioCreacion = rol.IdUsuario
            });

            return Ok("Rol registrado correctamente");
        }

        [HttpPost("UpdateRol")]
        public ActionResult Put([FromBody] RolUpdateDto rol)
        {
            repository.Update(new Rol
            {
                Descripcion = rol.Descripcion,
                Id = rol.Id,
                FechaMod = rol.ChangeTime,
                IdUsuarioMod = rol.IdUsuario
            });

            return Ok("Rol actualizado correctamente");
        }


        [HttpPost("DeleteRol")]
        public ActionResult Delete([FromBody] RolDeleteDto rol)
        {
            repository.Remove(new Rol()
            {
                Id = rol.Id,
                FechaElimino = rol.ChangeTime,
                IdUsuarioElimino = rol.IdUsuario
            });

            return Ok("Rol eliminado correctamente");
        }

    }
}
