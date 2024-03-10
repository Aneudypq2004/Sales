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
            var detalleVenta = this.detalleVentaRepository.GetEntities().Select(dv => new DetalleVentaModel()
            {  
                Id = dv.Id,
                MarcaProducto = dv.MarcaProducto,
                DescripcionProducto = dv.DescripcionProducto,
                CategoriaProducto = dv.CategoriaProducto,
                Cantidad = dv.Cantidad,
                Precio = dv.Precio,
                Total = dv.Total
            }); 

            return Ok(detalleVenta);
        }

        
        [HttpGet("GetDetalleVentaById")]
        public IActionResult Get(int id)
        {
            var detalleVenta = this.detalleVentaRepository.GetEntity(id);

            var detalleVentaModel = new DetalleVentaModel()
            {
                Id = detalleVenta!.Id,
                MarcaProducto = detalleVenta.MarcaProducto,
                DescripcionProducto = detalleVenta.DescripcionProducto,
                CategoriaProducto = detalleVenta.CategoriaProducto,
                Cantidad = detalleVenta.Cantidad,
                Precio = detalleVenta.Precio,
                Total = detalleVenta.Total
            };

            return Ok(detalleVentaModel);
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

            //return Ok("El detalle de venta Se ha guardado.");
        }

        
        [HttpPut("ActualizarDetalleVenta")]
        public IActionResult Put( [FromBody] DetalleVentaModel detalleVentaUpdateModel)
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
            return Ok("El detalle de venta ha sido actualizado");
        }

        
        [HttpDelete("RemoveDetalleVenta")]
        public IActionResult Delete(int id)
        {
            this.detalleVentaRepository.Remove
            (
                new DetalleVenta()
                {
                    Id = id
                }
            );
            return Ok("Este detalle de venta ha sido eliminado");
        }
    }
}
