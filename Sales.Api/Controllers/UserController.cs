using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities.ModuloUsuario;
using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpGet]
        public ActionResult Get()
        {
            var result = repository.GetEntities();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = repository.GetEntity(id);

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserModel user)
        {
            repository.Save(new Usuario()
            {
                
                Nombre = user.Nombre,
                Correo = user.Correo
               });

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserModel user)
        {
            repository.Update(new Usuario()
            {
                Id = id,
                Nombre = user.Nombre,
                Correo = user.Correo
            });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
