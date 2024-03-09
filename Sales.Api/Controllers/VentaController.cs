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
        private IVentaRepository ventaRepository;

        public VentaController(IVentaRepository ventaRepository)
        {
            this.ventaRepository = ventaRepository;
        }

        
        [HttpGet("GetVentas")]
        public IActionResult Get()
        {
            var venta = this.ventaRepository.GetEntities();
            return Ok(venta);
        }

        
        [HttpGet("GetVentaById")]
        public IActionResult Get(int id)
        {
            var venta = this.ventaRepository.GetEntity(id);
            return Ok(venta);
        }

        
        [HttpPost]
        public void Post([FromBody] VentaModel ventaAddModel)
        {
            this.ventaRepository.Save(
                new Venta() {
                    Id = ventaAddModel.Id,

                    NombreCliente = ventaAddModel.NombreCliente,
                    SubTotal = ventaAddModel.SubTotal,
                    ImpuestoTotal = ventaAddModel.ImpuestoTotal,
                    Total = ventaAddModel.Total,
                    FechaRegistro = ventaAddModel.FechaRegistro
                }
            ); 
            
        }

        // PUT api/<VentaController>/5
        [HttpPut("ActualizarVenta")]
        public void Put([FromBody] VentaModel ventaUpdateModel)
        {
            this.ventaRepository.Update
            (
                new Venta()
                {
                    NombreCliente = ventaUpdateModel.NombreCliente,
                    SubTotal = ventaUpdateModel.SubTotal,
                    ImpuestoTotal = ventaUpdateModel.SubTotal,
                    Total = ventaUpdateModel.Total,
                }
            );
        }

        // DELETE api/<VentaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
        }
    }
}
