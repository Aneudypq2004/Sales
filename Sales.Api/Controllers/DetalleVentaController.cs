using Microsoft.AspNetCore.Mvc;
using Sales.Application.Contracts.Interfaces;
using Sales.Application.Dtos.DetalleVenta;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private readonly IDetalleVentaService detalleVentaService;

        public DetalleVentaController (IDetalleVentaService detalleVentaService)
        {
            this.detalleVentaService = detalleVentaService;
        }

    [HttpGet("GetDetalleVentas")]
        public IActionResult Get()
        {
            /*var detalleVenta = this.detalleVentaService.GetEntities().Select(dv => new DetalleVentaGetModel()
            {  
                Id = dv.Id,
                MarcaProducto = dv.MarcaProducto,
                DescripcionProducto = dv.DescripcionProducto,
                CategoriaProducto = dv.CategoriaProducto,
                Cantidad = dv.Cantidad,
                Precio = dv.Precio,
                Total = dv.Total
            });*/ 
            var result = this.detalleVentaService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpGet("GetDetalleVentaById")]
        public IActionResult Get(int id)
        {
            var result = this.detalleVentaService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }


            return Ok(result);
        }

       
        [HttpPost("SaveDetalleVenta")]
        public IActionResult Post([FromBody] DetalleVentaAddDto detalleVentaAddDto)
        {
            var result = this.detalleVentaService.Save(detalleVentaAddDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }


            return Ok(result);
        }

        
        [HttpPut("ActualizarDetalleVenta")]
        public IActionResult Put( [FromBody] DetalleVentaUpdateDto detalleVentaUpdateDto)
        {
            var result = this.detalleVentaService.Update(detalleVentaUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }


            return Ok(result);
        }

        
        [HttpDelete("RemoveDetalleVenta")]
        public IActionResult Delete(DetalleVentaRemoveDto detalleVentaRemoveDto)
        {
            var result = this.detalleVentaService.Remove(detalleVentaRemoveDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }


            return Ok(result);
        }
    }
}
