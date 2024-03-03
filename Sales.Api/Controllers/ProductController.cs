using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Repositories;


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
            var products = productRepository.GetEntities();
            return Ok(products);
        }

        

        [HttpGet("GetProductById")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetEntity(id);
            return Ok(product);
        }


        // POST api/<ProductController>
        [HttpPost("SaveProduct")]
        public void Post([FromBody] ProductAddModel productAddModel)
        {
            productRepository.Save(new Domain.Entities.Production.Product()
            {
                Id = productAddModel.Id,
                CodigoBarra = productAddModel.CodigoDeBarra,
                Marca = productAddModel.Marca,
                Descripcion = productAddModel.Descripcion,
                IdCategoria = productAddModel.IdCategory,
                Stock = productAddModel.Stock,
                UrlImagen = productAddModel.UrlImagen,
                NombreImagen = productAddModel.NombreImagen,
                Precio = productAddModel.Precio
            });
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
