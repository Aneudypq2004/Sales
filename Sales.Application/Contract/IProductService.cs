using Sales.Application.Dtos.Product;
using Sales.Application.Core;
using Sales.Application.Models.Product;

namespace Sales.Application.Contract
{
    public interface IProductService : IBaseService<ProductGetModel, ProductAddDto, ProductUpdateDto, ProductRemoveDto>
    {
        ServiceResult<ProductGetModel> GetProductsByCategory(int categoryId);
    }
}
