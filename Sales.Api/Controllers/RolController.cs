using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpGet]
        public ActionResult Get()
        {
            var result = repository.GetEntities();

            return Ok(result);
        }

        // GET api/<RolController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = repository.GetEntity(id);

            return Ok(result);
        }

        // POST api/<RolController>
        [HttpPost]
        public ActionResult Post([FromBody] RolModel rol)
        {
            repository.Save(new Rol()
            {
                Descripcion = rol.Descripcion

            });

            return NoContent();
        }

        // PUT api/<RolController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] RolModel rol)
        {
            repository.Update(new Rol
            {
                Descripcion = rol.Descripcion,
                Id = id
            });

            return NoContent();
        }
    }
}
