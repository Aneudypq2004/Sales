using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities;
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
            
             var result = this.tipoDocumentoVentaRepository.GetEntities().Select(tdv => new TipoDocumentoVentaModel()
             {
                 Id = tdv.Id,
                 Descripcion = tdv.Descripcion,
                 EsActivo = tdv.EsActivo,
                 Eliminado = tdv.Eliminado
             });
            
            return Ok(result);
        }

        
        [HttpGet("GetTipoDocumentoById")]
        public IActionResult Get(int id)
        {
            var tipoDocumentoVenta = this.tipoDocumentoVentaRepository.GetEntity(id);
            var tipoDocumentoVentaModel = new TipoDocumentoVentaModel()
            {
                Id = tipoDocumentoVenta!.Id,
                Descripcion = tipoDocumentoVenta.Descripcion,
                EsActivo = tipoDocumentoVenta.EsActivo,
                Eliminado = tipoDocumentoVenta.Eliminado
            };
            return Ok(tipoDocumentoVentaModel);
        }

        
        [HttpPost("SaveTipoDocumentoVenta")]
        public IActionResult Post([FromBody] TipoDocumentoVentaModel tipoDocumentoVentaAddModel)
        {
            this.tipoDocumentoVentaRepository.Save(
                new TipoDocumentoVenta()
                {
                    Id = tipoDocumentoVentaAddModel.Id,
                    Descripcion = tipoDocumentoVentaAddModel.Descripcion,
                    EsActivo = tipoDocumentoVentaAddModel.EsActivo,
                    Eliminado = tipoDocumentoVentaAddModel.Eliminado
                });
            return Ok("Este Tipo de documento ha sido guardado.");
        }

        
        [HttpPut("UpdateTipoDocumentoVenta")]
        public IActionResult Put([FromBody] TipoDocumentoVentaModel tipoDocumentoVentaUpdateModel)
        {
            this.tipoDocumentoVentaRepository.Update(
                new TipoDocumentoVenta()
                {  
                    Id = tipoDocumentoVentaUpdateModel.Id,
                    Descripcion = tipoDocumentoVentaUpdateModel.Descripcion,
                    EsActivo = tipoDocumentoVentaUpdateModel.EsActivo,
                    Eliminado = tipoDocumentoVentaUpdateModel.Eliminado
                });
            return Ok("Este Tipo de documento ha sido actualizado.");
        }


        // DELETE api/<TipoDocumentoVentaController>/5
        [HttpDelete("RemoveTipoDocumentoVenta")]
        public IActionResult Delete(int id)
        {
            this.tipoDocumentoVentaRepository.Remove
            (
                new TipoDocumentoVenta()
                {
                    Id = id
                }
            );

            return Ok("Este Tipo de documento ha sido eliminado");
        }
    }
}
