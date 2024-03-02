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
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationRepository repository;

        public ConfigurationController(IConfigurationRepository repository)
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

        [HttpPost]
        public ActionResult Post([FromBody] ConfigurationModel configuration)
        {
            repository.Save(new Configuracion()
            {
                Recurso = configuration.Recurso,
                Valor = configuration.Valor,
                Propiedad = configuration.Propiedad
            }); ;

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Put(short id, [FromBody] ConfigurationModel configuration)
        {
            repository.Update( new Configuracion()
            {
                Id = id,
                Recurso = configuration.Recurso,
                Valor = configuration.Valor,
                Propiedad = configuration.Propiedad
            }); ;

            return NoContent();
        }

        // DELETE api/<ConfigurationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
