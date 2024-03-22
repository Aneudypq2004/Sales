using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.NumeroCorrelativo;
using Sales.Api.models;
using Sales.Domain.Entities.negocios;
using Sales.Infrastructure.Interface;
using static System.Collections.Specialized.BitVector32;


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
            var result = this.numeroCorrelativoRepository.GetEntities().Select(cd =>new NumeroCorrelativoGetModel()
            {
                Id = cd.Id,
                UltimoNumero = cd.UltimoNumero,
                CantidadDigitos = cd.CantidadDigitos,
                Gestion = cd.Gestion
            });
            return Ok(result);
        }


        [HttpGet("GetNumeroCorrelativosById")]
        public IActionResult Get(int id)
        {
            var numeroCorrelativos = numeroCorrelativoRepository.GetEntity(id);
            if (numeroCorrelativos == null) return BadRequest();
            var numeroCorrelativosGetModel = new NumeroCorrelativoGetModel()
            {
                Id = id,
                UltimoNumero = numeroCorrelativos.UltimoNumero,
                CantidadDigitos = numeroCorrelativos.CantidadDigitos,
                Gestion = numeroCorrelativos.Gestion
            };
            return Ok(numeroCorrelativosGetModel);
        }



        [HttpPost("SaveNumeroCorrelativo")]
        public ActionResult Post([FromBody] NumeroCorrelativoAddDto numeroCorrelativoAddDto)
        {
            try
            {
                this.numeroCorrelativoRepository.Save(new NumeroCorrelativo()
            {
                UltimoNumero = numeroCorrelativoAddDto.UltimoNumero,
                CantidadDigitos = numeroCorrelativoAddDto.CantidadDigitos,
                Gestion = numeroCorrelativoAddDto.Gestion
            });
            }
            catch (Exception)
            {

                throw;
            }
            return Ok("el numero corelativo se a registrado correctamente");
        }

        // PUT api/<NumeroCorrelativoController>/5
        [HttpPut("UpdateNumeroCorrelativo")]
        public ActionResult Put([FromBody] NumeroCorrelativoUpdateDto numeroCorrelativoUpdateDto)
        {
            try
            {
                numeroCorrelativoRepository.Update(new NumeroCorrelativo()
                {
                    Id = numeroCorrelativoUpdateDto.Id,
                    UltimoNumero = numeroCorrelativoUpdateDto.UltimoNumero,
                    CantidadDigitos = numeroCorrelativoUpdateDto.CantidadDigitos,
                    Gestion = numeroCorrelativoUpdateDto.Gestion,
                    FechaActualizacion = numeroCorrelativoUpdateDto.ChangeTime
                });

            }
            catch (Exception)
            {

                throw;
            }
            return Ok("el numero corelativo se a actualizado correctamente");
        }

        // DELETE api/<NumeroCorrelativoController>/5
        [HttpDelete("DeleteNumeroCorrelativo")]
        public ActionResult Delete([FromBody]NumeroCorrelativoDeleteDto numeroCorrelativoDeleteDto)
        {
            try
            {
                numeroCorrelativoRepository.Remuve(new NumeroCorrelativo()
                {
                    Id = numeroCorrelativoDeleteDto.Id
                });
            }
            catch (Exception)
            {

                throw;
            }
            return Ok("el numero corelativo se a eliminado correctamente");
        }
    }
}
