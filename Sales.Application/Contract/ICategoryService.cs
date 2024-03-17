using Sales.Application.Models.Category;
using Sales.Application.Dtos.Category;

namespace Sales.Application.Contract
{
    public interface ICategoryService : IBaseService<CategoryGetModel, CategoryAddDto, CategoryUpdateDto, CategoryRemoveDto>
    {
    }
}
