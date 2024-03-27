using Microsoft.AspNetCore.Mvc;
using Sales.Application.Contracts.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService ventaService;

        public VentaController(IVentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        
        [HttpGet("GetVentas")]
        public IActionResult Get()
        {
            /* var venta = this.ventaRepository.GetEntities().Select(v => new VentaGetModel()
             {
                 Id = v.Id,
                 NombreCliente = v.NombreCliente,
                 SubTotal = v.SubTotal,
                 ImpuestoTotal = v.ImpuestoTotal,
                 Total = v.Total,
                 FechaRegistro = v.FechaRegistro
             });*/

            var result = this.ventaService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
           
        }

        
        [HttpGet("GetVentaById")]
        public IActionResult Get(int id)
        {
            var result = this.ventaService.GetById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpPost("SaveVenta")]
        public IActionResult Post([FromBody] Application.Dtos.venta.VentaAddDto ventaAddDto)
        {
            var result = this.ventaService.Save(ventaAddDto);

            if (!result.Success )
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpPut("ActualizarVenta")]
        public IActionResult Put([FromBody] Application.Dtos.venta.VentaUpdateDto ventaUpdateDto)
        {
            this.ventaService.Update
            (ventaUpdateDto);
            var result = this.ventaService.Update(ventaUpdateDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpDelete("RemoveVenta")]
        public IActionResult Delete(Application.Dtos.venta.VentaRemoveDto ventaRemoveDto)
        {
            this.ventaService.Remove(ventaRemoveDto);
            
                var result = this.ventaService.Remove(ventaRemoveDto);

                if (result.Success)
                {
                    return BadRequest(result);
                }
                return Ok(result);
           
                
        }
    }
}
