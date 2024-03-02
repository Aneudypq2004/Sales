using Sales.Domain.Entities.Production;
using Sales.Domain.Repository;
using Sales.Infrastructure.Model;

namespace Sales.Infrastructure.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        List<ProductModel> GetProductsByCategory(int categoryId);
    }
}
