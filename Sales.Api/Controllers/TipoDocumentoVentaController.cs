using Microsoft.AspNetCore.Mvc;
using Sales.Application.Contracts.Interfaces;
using Sales.Application.Dtos.TipoDocumentoVenta;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoVentaController : ControllerBase
    {
        private readonly ITipoDocumentoVentaService tipoDocumentoVentaService;

        public TipoDocumentoVentaController(ITipoDocumentoVentaService tipoDocumentoVentaService)
        {
            this.tipoDocumentoVentaService = tipoDocumentoVentaService;
        }

        
        [HttpGet("GetTipoDocumento")]
        public IActionResult Get()
        {

            var result = this.tipoDocumentoVentaService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpGet("GetTipoDocumentoById")]
        public IActionResult Get(int id)
        {
            var result = this.tipoDocumentoVentaService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpPost("SaveTipoDocumentoVenta")]
        public IActionResult Post([FromBody] TipoDocumentoVentaAddDto tipoDocumentoVentaAddDto)
        {
            var result = this.tipoDocumentoVentaService.Save(tipoDocumentoVentaAddDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpPut("UpdateTipoDocumentoVenta")]
        public IActionResult Put([FromBody] TipoDocumentoVentaUpdateDto tipoDocumentoVentaUpdateDto)
        {
            var result = this.tipoDocumentoVentaService.Update(tipoDocumentoVentaUpdateDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // DELETE api/<TipoDocumentoVentaController>/5
        [HttpDelete("RemoveTipoDocumentoVenta")]
        public IActionResult Delete(TipoDocumentoVentaRemoveDto tipoDocumentoVentaRemove)
        {
            var result = this.tipoDocumentoVentaService.Remove(tipoDocumentoVentaRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
