using Microsoft.AspNetCore.Mvc;
using Sales.Api.models;
using Sales.Domain.Entities.negocios;
using Sales.Infrastructure.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroCorrelativoController : ControllerBase
    {
        private readonly INumeroCorrelativoRepository numeroCorrelativoRepository;

        public NumeroCorrelativoController(INumeroCorrelativoRepository numeroCorrelativoRepository)
        {
            this.numeroCorrelativoRepository = numeroCorrelativoRepository;
        }
        [HttpGet("GetNumeroCorrelativos")]
        public IActionResult Get()
        {
            var numeroCorrelativos = this.numeroCorrelativoRepository.GetEntities();
            return Ok(numeroCorrelativos);
        }


        [HttpGet("GetNumeroCorrelativosById")]
        public IActionResult Get(int id)
        {
            var numeroCorrelativos = this.numeroCorrelativoRepository.GetEntity(id);
            return Ok(numeroCorrelativos);
        }



        [HttpPost("SaveNumeroCorrelativo")]
        public void Post([FromBody] NumeroCorrelativoAddModel numeroCorrelativoAddModel){
            this.numeroCorrelativoRepository.Save(new Domain.Entities.negocios.NumeroCorrelativo()
            {
                UltimoNumero = numeroCorrelativoAddModel.UltimoNumero,
                CantidadDigitos = numeroCorrelativoAddModel.CantidadDigitos,
                Gestion = numeroCorrelativoAddModel.Gestion,
                FechaActualizacion = numeroCorrelativoAddModel.FechaActualizacion
            });
        }

        // PUT api/<NumeroCorrelativoController>/5
        [HttpPut("{id}")]
        public void Put(int Id, [FromBody] string value)
        {
        }

        // DELETE api/<NumeroCorrelativoController>/5
        [HttpDelete("{id}")]
        public void Delete(int Id)
        {
        }
    }
}
