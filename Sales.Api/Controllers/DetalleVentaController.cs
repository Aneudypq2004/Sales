using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.DetalleVenta;
using Sales.Api.Models;
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
            var detalleVenta = this.detalleVentaRepository.GetEntities().Select(dv => new DetalleVentaGetModel()
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

            DetalleVentaGetModel detalleVentaGetModel = new DetalleVentaGetModel()
            {
                Id = detalleVenta!.Id,
                MarcaProducto = detalleVenta.MarcaProducto,
                DescripcionProducto = detalleVenta.DescripcionProducto,
                CategoriaProducto = detalleVenta.CategoriaProducto,
                Cantidad = detalleVenta.Cantidad,
                Precio = detalleVenta.Precio,
                Total = detalleVenta.Total
            };

           
            return Ok(detalleVentaGetModel);
        }

       
        [HttpPost("SaveDetalleVenta")]
        public IActionResult Post([FromBody] DetalleVentaAddDto detalleVentaAddDto)
        {
            this.detalleVentaRepository.Save(new DetalleVenta()
            {
                MarcaProducto = detalleVentaAddDto.MarcaProducto,
                DescripcionProducto = detalleVentaAddDto.DescripcionProducto,
                CategoriaProducto = detalleVentaAddDto.CategoriaProducto,
                Cantidad = detalleVentaAddDto.Cantidad,
                Precio = detalleVentaAddDto.Precio,
                Total = detalleVentaAddDto.Total
            });

            return Ok("El detalle de venta Se ha guardado.");
        }

        
        [HttpPut("ActualizarDetalleVenta")]
        public IActionResult Put( [FromBody] DetalleVentaUpdateDto detalleVentaUpdateDto)
        {

            this.detalleVentaRepository.Update
            (
                new DetalleVenta()
                {
                    MarcaProducto = detalleVentaUpdateDto.MarcaProducto,
                    DescripcionProducto = detalleVentaUpdateDto.DescripcionProducto,
                    CategoriaProducto = detalleVentaUpdateDto.CategoriaProducto,
                    Cantidad = detalleVentaUpdateDto.Cantidad,
                    Precio = detalleVentaUpdateDto.Precio,
                    Total = detalleVentaUpdateDto.Total
                }
            );
            return Ok("El detalle de venta ha sido actualizado");
        }

        
        [HttpDelete("RemoveDetalleVenta")]
        public IActionResult Delete(DetalleVentaRemoveDto detalleVentaRemoveDto)
        {
            this.detalleVentaRepository.Remove
            (
                new DetalleVenta()
                {
                    Id = detalleVentaRemoveDto.Id
                }
            );
            return Ok("Este detalle de venta ha sido eliminado");
        }
    }
}
