using Microsoft.AspNetCore.Mvc;
using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Inteface;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : ControllerBase
    {
        private IDetalleVentaRepository detalleVentaRepository;

        public DetalleVentaController (IDetalleVentaRepository detalleVentaRepository)
        {
            this.detalleVentaRepository = detalleVentaRepository;
        }

    [HttpGet("GetDetalleVentas")]
        public IActionResult Get()
        {
            var detalleVentas = this.detalleVentaRepository.GetEntities();
                return Ok(detalleVentas);
        }

        
        [HttpGet("GetDetalleVentaById")]
        public IActionResult Get(int id)
        {
            var detalleVenta = this.detalleVentaRepository.GetEntity(id);
            return Ok(detalleVenta);
        }

       
        [HttpPost("SaveDetalleVenta")]
        public void Post([FromBody] DetalleVentaModel detalleVentaAddModel)
        {
            this.detalleVentaRepository.Save(new DetalleVenta()
            {
                MarcaProducto = detalleVentaAddModel.MarcaProducto,
                DescripcionProducto = detalleVentaAddModel.DescripcionProducto,
                CategoriaProducto = detalleVentaAddModel.CategoriaProducto,
                Cantidad = detalleVentaAddModel.Cantidad,
                Precio = detalleVentaAddModel.Precio,
                Total = detalleVentaAddModel.Total
            });
        }

        
        [HttpPut("{id}")]
        public void Put( [FromBody] DetalleVentaModel detalleVentaUpdateModel)
        {

            this.detalleVentaRepository.Update
            (
                new DetalleVenta()
                {
                    MarcaProducto = detalleVentaUpdateModel.MarcaProducto,
                    DescripcionProducto = detalleVentaUpdateModel.DescripcionProducto,
                    CategoriaProducto = detalleVentaUpdateModel.CategoriaProducto,
                    Cantidad = detalleVentaUpdateModel.Cantidad,
                    Precio = detalleVentaUpdateModel.Precio,
                    Total = detalleVentaUpdateModel.Total
                }
            );
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
