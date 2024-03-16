using Sales.Api.Dtos.Category;
using Sales.Api.Models.Category;

namespace Sales.Application.Contract
{
    public interface ICategoryService : IBaseService<CategoryGetModel, CategoryAddDto, CategoryUpdateDto, CategoryRemoveDto>
    {
    }
}
