using Microsoft.AspNetCore.Mvc;
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
            var venta = this.ventaRepository.GetEntities().Select(v => new VentaModel()
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

            var VentaModel = new VentaModel()
            {
                Id = venta!.Id,
                NumeroVenta = venta!.NumeroVenta,
                NombreCliente = venta.NombreCliente,
                SubTotal = venta.SubTotal,
                ImpuestoTotal = venta.ImpuestoTotal,
                Total = venta.Total,
                FechaRegistro = venta.FechaRegistro
            };

            return Ok(VentaModel);
        }

        
        [HttpPost("SaveVenta")]
        public IActionResult Post([FromBody] VentaModel ventaAddModel)
        {
            this.ventaRepository.Save(
                new Venta() {
                    Id = ventaAddModel.Id,
                    NumeroVenta = ventaAddModel.NumeroVenta,
                    NombreCliente = ventaAddModel.NombreCliente,
                    SubTotal = ventaAddModel.SubTotal,
                    ImpuestoTotal = ventaAddModel.ImpuestoTotal,
                    Total = ventaAddModel.Total,
                    FechaRegistro = ventaAddModel.FechaRegistro
                }
            ); 
            return Ok("La venta ha sido guardada.");
        }

        // PUT api/<VentaController>/5
        [HttpPut("ActualizarVenta")]
        public IActionResult Put([FromBody] VentaModel ventaUpdateModel)
        {
            this.ventaRepository.Update
            (
                new Venta()
                {   
                    NumeroVenta = ventaUpdateModel.NumeroVenta,
                    NombreCliente = ventaUpdateModel.NombreCliente,
                    SubTotal = ventaUpdateModel.SubTotal,
                    ImpuestoTotal = ventaUpdateModel.SubTotal,
                    Total = ventaUpdateModel.Total,
                }
            );

            return Ok("La Venta ha sido actualizada.");
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("RemoveVenta")]
        public IActionResult Delete(int id)
        {
            this.ventaRepository.Remove
            (
                new Venta()
                {
                    Id = id
                }
            );

            return Ok("La Venta ha sido eliminada");
        }
    }
}
