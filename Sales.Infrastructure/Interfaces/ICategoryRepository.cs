using Sales.Domain.Entities.Production;

namespace Sales.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        void Update(Category category);
        void Remove(Category category);
        List<Category> GetCategories();
        Category? GetCategory(int id);
    }
}
