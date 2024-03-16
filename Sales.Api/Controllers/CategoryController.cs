using Microsoft.AspNetCore.Mvc;
using Sales.Api.Dtos.Category;
using Sales.Api.Models.Category;
using Sales.Domain.Entities.Production;
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
            var categories = categoryRepository.GetEntities().Select(cd => new CategoryGetModel()
            {
                Id = cd.Id,
                Description = cd.Descripcion,
                FechaRegistro = cd.FechaRegistro
            });

            return Ok(categories);
        }



        [HttpGet("GetCategoryById")]
        public IActionResult Get(int id)
        {
            var category = categoryRepository.GetEntity(id);

            CategoryGetModel categoryGetModel = new CategoryGetModel()
            {
                Id = category.Id,
                Description = category.Descripcion,
                FechaRegistro = category.FechaRegistro
            };

            return Ok(categoryGetModel);
        }


        
        [HttpPost("SaveCategory")]
        public IActionResult Post([FromBody] CategoryAddDto categoryAddDto)
        {
            categoryRepository.Save(new Domain.Entities.Production.Category()
            {
                FechaRegistro = categoryAddDto.ChangeDate,
                IdUsuarioCreacion = categoryAddDto.UserId,
                Id = categoryAddDto.Id,
                Descripcion = categoryAddDto.Descripcion
            });

            return Ok("Categoria guardada correctamente.");

        }


        [HttpPost("UpdateCategory")]
        public IActionResult Put([FromBody] CategoryUpdateDto categoryUpdte)
        {
            this.categoryRepository.Update(new Category()
            {
                Id = categoryUpdte.Id,
                FechaMod = categoryUpdte.ChangeDate,
                IdUsuarioMod = categoryUpdte.UserId,
                Descripcion = categoryUpdte.Descripcion,
            });

            return Ok("Categoria actualizada correctamente.");
        }
        

        [HttpPost("RemoveCategory")]
        public IActionResult Remove([FromBody] CategoryRemoveDto categoryRemove)
        {
            this.categoryRepository.Remove(new Category()
            {
                Id = categoryRemove.Id,
                Descripcion = categoryRemove.Descripcion,
                FechaElimino = categoryRemove.ChangeDate,
                IdUsuarioElimino = categoryRemove.UserId
            });

            return Ok("Categoria eliminada correctamente.");
        }
    }
}

