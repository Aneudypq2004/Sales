using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Product;
using Sales.Api.Models.Product;
using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Interfaces;


namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("GetProducts")]
        public IActionResult Get()
        {
            var products = productRepository.GetEntities().Select(cd => new ProductGetModel()
            {
                Id = cd.Id,
                Marca = cd.Marca,
                Descripcion = cd.Descripcion,
                IdCategory = cd.IdCategoria,
                Stock = cd.Stock,
                UrlImagen = cd.UrlImagen,
                NombreImagen = cd.NombreImagen,
                Precio = cd.Precio,
                FechaRegistro = cd.FechaRegistro,
            });

            return Ok(products);
        }

        

        [HttpGet("GetProductById")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetEntity(id);

            ProductGetModel productGetModel = new ProductGetModel()
            {
                Id = product.Id,
                Descripcion = product.Descripcion,
                FechaRegistro = product.FechaRegistro
            };

            return Ok(productGetModel);
        }


        [HttpPost("SaveProduct")]
        public void Post([FromBody] ProductAddDto productAddModel)
        {
            productRepository.Save(new Domain.Entities.Production.Product()
            {
                Id = productAddModel.Id,
                Marca = productAddModel.Marca,
                Descripcion = productAddModel.Descripcion,
                IdCategoria = productAddModel.IdCategory,
                Stock = productAddModel.Stock,
                UrlImagen = productAddModel.UrlImagen,
                NombreImagen = productAddModel.NombreImagen,
                Precio = productAddModel.Precio,
                FechaRegistro = productAddModel.FechaRegistro,
            });
        }

        [HttpPost("UpdateProduct")]
        public IActionResult Put([FromBody] ProductUpdateDto productUpdate)
        {
            productRepository.Update(new Product()
            {
                Id = productUpdate.Id,
                FechaMod = productUpdate.ChangeDate,
                IdUsuarioMod = productUpdate.UserId,
                Descripcion = productUpdate.Descripcion,
            });

            return Ok("Producto actualizado correctamente.");
        }

        [HttpPost("RemoveProduct")]
        public IActionResult Remove([FromBody] ProductRemoveDto productRemove)
        {
            productRepository.Remove(new Product()
            {
                Id = productRemove.Id,
                FechaElimino = productRemove.ChangeDate,
                IdUsuarioElimino = productRemove.UserId
            });

            return Ok("Producto eliminado correctamente.");
        }
    }
}
