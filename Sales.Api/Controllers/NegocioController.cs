using Microsoft.AspNetCore.Mvc;
using Sales.Api.models;
using Sales.Infrastructure.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NegocioController : ControllerBase
    {
        private readonly INegocioRepository negocioRepository;

        public NegocioController(INegocioRepository negocioRepository)
        {
            this.negocioRepository = negocioRepository;
        }
        
        [HttpGet("GetNegocio")]
        public IActionResult Get()
        {
            var Negocios = this.negocioRepository.GetEntities();
            return Ok(Negocios);
        }

        
        [HttpGet("GetNegocioById")]
        public IActionResult Get(int id)
        {
            var Negocio = this.negocioRepository.GetEntity(id);
            return Ok(Negocio);
        }

       
        [HttpPost("SaveNegocio")]
        public void Post([FromBody] NegocioAddModel negocioAddModel)
        {
            try
            {
                this.negocioRepository.Save(new Domain.Entities.negocios.Negocio()
                {
                    UrlLogo = negocioAddModel.UrlLogo,
                    NombreLogo = negocioAddModel.NombreLogo,
                    NumeroDocumento = negocioAddModel.NumeroDocumento,
                    Nombre = negocioAddModel.Nombre,
                    Correo = negocioAddModel.Correo,
                    Direccion = negocioAddModel.Direccion,
                    Telefono = negocioAddModel.Telefono,
                    PorcentajeImpuesto = negocioAddModel.PorcentajeImpuesto,
                    SimboloMoneda = negocioAddModel.SimboloMoneda
                });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/<NegocioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NegocioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
