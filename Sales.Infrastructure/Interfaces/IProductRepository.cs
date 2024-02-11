using Sales.Domain.Entities.Production;

namespace Sales.Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product product);
        void Update(Product product);
        void Remove(Product product);
        List<Product> GetProducts();
        Product? GetProduct(int id);
    }
}
