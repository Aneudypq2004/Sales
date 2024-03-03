using Microsoft.AspNetCore.Mvc;
using Sales.Api.Models;
using Sales.Infrastructure.Interfaces;


namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
            var categories = categoryRepository.GetEntities();
            return Ok(categories);
        }



        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var category = categoryRepository.GetEntity(id);
            return Ok(category);
        }


        
        [HttpPost("SaveProduct")]
        public void Post([FromBody] CategoryAddModel categoryAddModel)
        {
            categoryRepository.Save(new Domain.Entities.Production.Category()
            {
                Descripcion = categoryAddModel.Descripcion
            });
        }

        // we have to change to HttpPost and also we manage 

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

