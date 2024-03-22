using Microsoft.AspNetCore.Mvc;
using Sales.Api.models;
using Sales.Api.Dtos.Negocio;
using Sales.Infrastructure.Interface;
using Sales.Domain.Entities.negocios;

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
            var result = negocioRepository.GetEntities().Select(cd => new NegocioGetModel()
            {
                Id = cd.Id,
                UrlLogo = cd.UrlLogo,
                NombreLogo = cd.NombreLogo,
                NumeroDocumento = cd.NumeroDocumento,
                Nombre = cd.Nombre,
                Correo = cd.Correo,
                Direccion = cd.Direccion,
                Telefono = cd.Telefono,
                PorcentajeImpuesto = cd.PorcentajeImpuesto,
                SimboloMoneda = cd.SimboloMoneda
            });
            
            return Ok(result);
        }

        
        [HttpGet("GetNegocioById")]
        public IActionResult Get(int id)
        {
            var negocio = negocioRepository.GetEntity(id);
            if (negocio is null) return BadRequest();
            var negociosGetModel = new NegocioGetModel() 
            {
                Id = id,
                UrlLogo = negocio.UrlLogo,
                NombreLogo = negocio.NombreLogo,
                NumeroDocumento = negocio.NumeroDocumento,
                Nombre= negocio.Nombre,
                Correo = negocio.Correo,
                Direccion = negocio.Direccion,
                Telefono = negocio.Telefono,
                PorcentajeImpuesto = negocio.PorcentajeImpuesto,
                SimboloMoneda = negocio.SimboloMoneda
            };
            return Ok(negociosGetModel);
        }

       
        [HttpPost("SaveNegocio")]
        public ActionResult Post([FromBody] NegocioAddDto negocioAddDto)
        {
            try
            {
                negocioRepository.Save(new Negocio()
                {
                    UrlLogo = negocioAddDto.UrlLogo,
                    NombreLogo = negocioAddDto.NombreLogo,
                    NumeroDocumento = negocioAddDto.NumeroDocumento,
                    Nombre = negocioAddDto.Nombre,
                    Correo = negocioAddDto.Correo,
                    Direccion = negocioAddDto.Direccion,
                    Telefono = negocioAddDto.Telefono,
                    PorcentajeImpuesto = negocioAddDto.PorcentajeImpuesto,
                    SimboloMoneda = negocioAddDto.SimboloMoneda,
                    IdUsuarioCreacion = negocioAddDto.UsuarioId,
                    FechaRegistro = negocioAddDto.ChangeTime
                });
            }
            catch (Exception)
            {

                throw;
            }
            return Ok("Negocio registrado correctamente");
        }

        // PUT api/<NegocioController>/5
        [HttpPut("UpdateNegocio")]
        public ActionResult Put(int id, [FromBody] NegocioUpdateDto negocioUpdateDto)
        {
            try
            {
                this.negocioRepository.Update(new Negocio()
                {
                    Id = negocioUpdateDto.Id, 
                    UrlLogo = negocioUpdateDto.UrlLogo,
                    NombreLogo = negocioUpdateDto.NombreLogo,
                    NumeroDocumento = negocioUpdateDto.NumeroDocumento,
                    Nombre = negocioUpdateDto.Nombre,
                    Correo = negocioUpdateDto.Correo,
                    Direccion = negocioUpdateDto.Direccion,
                    Telefono = negocioUpdateDto.Telefono,
                    PorcentajeImpuesto = negocioUpdateDto.PorcentajeImpuesto,
                    SimboloMoneda = negocioUpdateDto.SimboloMoneda,
                    IdUsuarioMod = negocioUpdateDto.UsuarioId,
                    FechaMod = negocioUpdateDto.ChangeTime
                });
            }
            catch (Exception)
            {

                throw;
            }
            return Ok("Negocio actualizado correctamente");
        }

        // DELETE api/<NegocioController>/5
        [HttpPut("DeleteNegocio")]
        public ActionResult Delete([FromBody] NegocioDeleteDto negocioDeleteDto) 
        {
            try
            {
                this.negocioRepository.Remuve(new Negocio()
                {
                    Id = negocioDeleteDto.Id,
                    FechaElimino = negocioDeleteDto.ChangeTime,
                    IdUsuarioElimino = negocioDeleteDto.UsuarioId

                });

            }
            catch (Exception)
            {

                throw;
            }
            return Ok("Negocio eliminado correctamente");
        }
    }
}
