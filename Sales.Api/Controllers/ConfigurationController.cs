using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.Configuration;
using Sales.Application.Models;
using Sales.Domain.Entities.Usuario.Usuario;
using Sales.Infrastructure.Interfaces;


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

        [HttpGet("GetConfigurations")]
        public ActionResult Get()
        {
            var result = repository.GetEntities().Select(e => new ConfigurationGetModel()
            {
                Id = e.Id,
                Recurso = e.Recurso,
                Valor = e.Valor,
                Propiedad = e.Propiedad
            } );

            return Ok(result);
        }

        [HttpGet("GetConfigurationByID")]
        public ActionResult Get(short id)
        {
            var result = repository.GetEntity(id);

            if (result is null) return BadRequest();
;
           var configuration =  new ConfigurationGetModel()
            {
                Id = result.Id,
                Recurso = result.Recurso,
                Valor = result.Valor,
                Propiedad = result.Propiedad
            };

            return Ok(configuration);
        }

        [HttpPost("AddConfiguration")]
        public ActionResult Post([FromBody] ConfigurationAddDto configuration)
        {
            repository.Save(new Configuracion()
            {
                Recurso = configuration.Recurso,
                Valor = configuration.Valor,
                Propiedad = configuration.Propiedad
            }); ;

            return Ok("Configuracion agregada correctamente");
        }

        [HttpPost("ActualizarConfiguration")]
        public ActionResult Put([FromBody] ConfigurationUpdateDto configuration)
        {
            repository.Update( new Configuracion()
            {
                Id = configuration.Id,
                Recurso = configuration.Recurso,
                Valor = configuration.Valor,
                Propiedad = configuration.Propiedad
            }); ;

            return Ok("Configuracion actualizada correctamente");
        }

        [HttpPost("DeleteConfiguration")]
        public ActionResult Delete([FromBody] ConfigurationDeleteDto configuration)
        {
            repository.Remove(new Configuracion()
            {
                Id = configuration.Id
            });

            return Ok("Eliminado correctamente");
        }
    }
}
