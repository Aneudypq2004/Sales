using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Inteface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoVentaController : ControllerBase
    {
        private ITipoDocumentoVentaRepository tipoDocumentoVentaRepository;

        public TipoDocumentoVentaController(ITipoDocumentoVentaRepository tipoDocumentoVentaRepository)
        {
            this.tipoDocumentoVentaRepository = tipoDocumentoVentaRepository;
        }

        // GET: api/<TipoDocumentoVentaController>
        [HttpGet("GetTipoDocumento")]
        public IActionResult Get()
        {
            
             var result = this.tipoDocumentoVentaRepository.GetEntities();
            return Ok(result);
        }

        // GET api/<TipoDocumentoVentaController>/5
        [HttpGet("GetTipoDocumentoById")]
        public IActionResult Get(int id)
        {
            var result  = this.tipoDocumentoVentaRepository.GetEntity(id);
            return Ok(result);
        }

        // POST api/<TipoDocumentoVentaController>
        [HttpPost("SaveTipoDocumentoVenta")]
        public void Post([FromBody] TipoDocumentoVentaModel tipoDocumentoVentaAddModel)
        {
            this.tipoDocumentoVentaRepository.Save(
                new TipoDocumentoVenta()
                {
                    Id = tipoDocumentoVentaAddModel.Id,
                    Descripcion = tipoDocumentoVentaAddModel.Descripcion,
                    EsActivo = tipoDocumentoVentaAddModel.EsActivo,
                    Eliminado = tipoDocumentoVentaAddModel.Eliminado
                });
        }

        // PUT api/<TipoDocumentoVentaController>/5
        [HttpPut("UpdateTipoDocumentoVenta")]
        public void Put([FromBody] TipoDocumentoVentaModel tipoDocumentoVentaUpdateModel)
        {
            this.tipoDocumentoVentaRepository.Update(
                new TipoDocumentoVenta()
                {  
                    Id = tipoDocumentoVentaUpdateModel.Id,
                    Descripcion = tipoDocumentoVentaUpdateModel.Descripcion,
                    EsActivo = tipoDocumentoVentaUpdateModel.EsActivo,
                    Eliminado = tipoDocumentoVentaUpdateModel.Eliminado
                });
        }

        // DELETE api/<TipoDocumentoVentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
