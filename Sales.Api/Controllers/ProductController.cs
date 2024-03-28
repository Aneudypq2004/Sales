using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.Product;
using Sales.Application.Contract;


namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetProducts")]
        public IActionResult Get()
        {
            var result = productService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetProductById")]
        public IActionResult Get(int id)
        {
            var result = productService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetProductsByCategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = productService.GetProductsByCategory(categoryId);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("SaveProduct")]
        public IActionResult Post([FromBody] ProductAddDto productAdd)
        {
            var result = productService.Save(productAdd);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("UpdateProduct")]
        public IActionResult Put([FromBody] ProductUpdateDto productUpdate)
        {
            var result = productService.Update(productUpdate);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("RemoveProduct")]
        public IActionResult Remove([FromBody] ProductRemoveDto productRemove)
        {
            var result = productService.Remove(productRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
