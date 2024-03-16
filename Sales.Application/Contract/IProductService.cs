using Sales.Api.Dtos.Product;
using Sales.Api.Models.Product;
using Sales.Application.Core;

namespace Sales.Application.Contract
{
    public interface IProductService : IBaseService<ProductGetModel, ProductAddDto, ProductUpdateDto, ProductRemoveDto>
    {
        ServiceResult<List<ProductGetModel>> GetProductsByCategory(int categoryId);
    }
}
