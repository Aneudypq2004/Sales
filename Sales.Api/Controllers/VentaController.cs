using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.venta;
using Sales.Domain.Entities;
using Sales.Infrastructure.Inteface;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaRepository ventaRepository;

        public VentaController(IVentaRepository ventaRepository)
        {
            this.ventaRepository = ventaRepository;
        }

        
        [HttpGet("GetVentas")]
        public IActionResult Get()
        {
            var venta = this.ventaRepository.GetEntities().Select(v => new VentaGetModel()
            {
                Id = v.Id,
                NombreCliente = v.NombreCliente,
                SubTotal = v.SubTotal,
                ImpuestoTotal = v.ImpuestoTotal,
                Total = v.Total,
                FechaRegistro = v.FechaRegistro
            });
            return Ok(venta);
        }

        
        [HttpGet("GetVentaById")]
        public IActionResult Get(int id)
        {
            var venta = this.ventaRepository.GetEntity(id);

            VentaGetModel ventaGetModel = new VentaGetModel()
            {
                Id = venta!.Id,
                NombreCliente = venta.NombreCliente,
                SubTotal = venta.SubTotal,
                ImpuestoTotal = venta.ImpuestoTotal,
                Total = venta.Total,
                FechaRegistro = venta.FechaRegistro
            };

            return Ok(ventaGetModel);
        }

        
        [HttpPost("SaveVenta")]
        public IActionResult Post([FromBody] VentaAddDto ventaAddDto)
        {
            this.ventaRepository.Save(
                new Venta() {
                    Id = ventaAddDto.Id,
                    NombreCliente = ventaAddDto.NombreCliente,
                    SubTotal = ventaAddDto.SubTotal,
                    ImpuestoTotal = ventaAddDto.ImpuestoTotal,
                    Total = ventaAddDto.Total,
                    FechaRegistro = ventaAddDto.FechaRegistro
                }
            ); 
            return Ok("La venta ha sido guardada.");
        }

        // PUT api/<VentaController>/5
        [HttpPut("ActualizarVenta")]
        public IActionResult Put([FromBody] VentaUpdateDto ventaUpdateDto)
        {
            this.ventaRepository.Update
            (
                new Venta()
                {   
                   
                    NombreCliente = ventaUpdateDto.NombreCliente,
                    SubTotal = ventaUpdateDto.SubTotal,
                    ImpuestoTotal = ventaUpdateDto.SubTotal,
                    Total = ventaUpdateDto.Total,
                }
            );

            return Ok("La Venta ha sido actualizada.");
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("RemoveVenta")]
        public IActionResult Delete(VentaRemoveDto ventaRemoveDto)
        {
            this.ventaRepository.Remove
            (
                new Venta()
                {
                    Id = ventaRemoveDto.Id
                }
            );

            return Ok("La Venta ha sido eliminada");
        }
    }
}
