using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.TipoDocumentoVenta;
using Sales.Api.Models;
using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Inteface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoVentaController : ControllerBase
    {
        private readonly ITipoDocumentoVentaRepository tipoDocumentoVentaRepository;

        public TipoDocumentoVentaController(ITipoDocumentoVentaRepository tipoDocumentoVentaRepository)
        {
            this.tipoDocumentoVentaRepository = tipoDocumentoVentaRepository;
        }

        
        [HttpGet("GetTipoDocumento")]
        public IActionResult Get()
        {
            
             var result = this.tipoDocumentoVentaRepository.GetEntities().Select(tdv => new TipoDocumentoVentaGetModel()
             {
                 Id = tdv.Id,
                 Descripcion = tdv.Descripcion,
                 EsActivo = tdv.EsActivo
             });
            
            return Ok(result);
        }

        
        [HttpGet("GetTipoDocumentoById")]
        public IActionResult Get(int id)
        {
            var tipoDocumentoVenta = this.tipoDocumentoVentaRepository.GetEntity(id);
            TipoDocumentoVentaGetModel tipoDocumentoVentaGetModel= new TipoDocumentoVentaGetModel()
            {
                Id = tipoDocumentoVenta!.Id,
                Descripcion = tipoDocumentoVenta.Descripcion,
                EsActivo = tipoDocumentoVenta.EsActivo
            };
            return Ok(tipoDocumentoVentaGetModel);
        }

        
        [HttpPost("SaveTipoDocumentoVenta")]
        public IActionResult Post([FromBody] TipoDocumentoVentaAddDto tipoDocumentoVentaAddDto)
        {
            this.tipoDocumentoVentaRepository.Save( 
                new TipoDocumentoVenta()
                {
                    Id = tipoDocumentoVentaAddDto.Id,
                    Descripcion = tipoDocumentoVentaAddDto.Descripcion,
                    EsActivo = tipoDocumentoVentaAddDto.EsActivo
                    
                });
            return Ok("Este Tipo de documento ha sido guardado.");
        }

        
        [HttpPut("UpdateTipoDocumentoVenta")]
        public IActionResult Put([FromBody] TipoDocumentoVentaUpdateDto tipoDocumentoVentaUpdateDto)
        {
            this.tipoDocumentoVentaRepository.Update(
                new TipoDocumentoVenta()
                {  
                    Id = tipoDocumentoVentaUpdateDto.Id,
                    Descripcion = tipoDocumentoVentaUpdateDto.Descripcion,
                    EsActivo = tipoDocumentoVentaUpdateDto.EsActivo
                });
            return Ok("Este Tipo de documento ha sido actualizado.");
        }

        // DELETE api/<TipoDocumentoVentaController>/5
        [HttpDelete("RemoveTipoDocumentoVenta")]
        public IActionResult Delete(TipoDocumentoVentaRemoveDto tipoDocumentoVentaRemove)
        {
            this.tipoDocumentoVentaRepository.Remove
            (
                new TipoDocumentoVenta()
                {
                    Id = tipoDocumentoVentaRemove.Id
                }
            );

            return Ok("Este Tipo de documento ha sido eliminado");
        }
    }
}
