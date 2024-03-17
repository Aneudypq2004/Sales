using Microsoft.AspNetCore.Mvc;
using Sales.Application.Dtos.Category;
using Sales.Application.Contract;


namespace Sales.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("GetCategories")]
        public IActionResult Get()
        {
            var result = categoryService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }



        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var result = categoryService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        
        [HttpPost("SaveCategory")]
        public IActionResult Post([FromBody] CategoryAddDto categoryAddDto)
        {
            var result = categoryService.Save(categoryAddDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPost("UpdateCategory")]
        public IActionResult Put([FromBody] CategoryUpdateDto categoryUpdteDto)
        {
            var result = categoryService.Update(categoryUpdteDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        

        [HttpPost("RemoveCategory")]
        public IActionResult Remove([FromBody] CategoryRemoveDto categoryRemove)
        {
            var result = categoryService.Remove(categoryRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

