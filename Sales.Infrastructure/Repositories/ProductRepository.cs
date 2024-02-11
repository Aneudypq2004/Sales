using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SalesContext context;

        public ProductRepository(SalesContext context)
        {
            this.context = context;
        }

        public void Create(Product product)
        {
            try
            {
                this.context.Producto.Add(product);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Product? GetProduct(int id)
        {
            return this.context.Producto.Find();
        }

        public List<Product> GetProducts()
        {
            return this.context.Producto.Where(ca => !ca.Eliminado).ToList();
        }

        public void Remove(Product product)
        {
            try
            {
                var ProductToRemove = this.GetProduct(product.Id);

                ProductToRemove.Eliminado = true;
                ProductToRemove.FechaElimino = product.FechaElimino;
                ProductToRemove.IdUsuarioElimino = product.IdUsuarioElimino;

                this.context.Producto.Update(ProductToRemove);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Product product)
        {
            try
            {
                var ProductToUpdate = this.GetProduct(product.Id);

                ProductToUpdate.Id = product.Id;
                ProductToUpdate.Descripcion = product.Descripcion;
                ProductToUpdate.IdUsuarioMod = product.IdUsuarioMod;
                ProductToUpdate.FechaMod = product.FechaMod;

                this.context.Producto.Update(ProductToUpdate);
                this.context.SaveChanges();
            }
            catch(Exception) 
            {
                throw;
            }
        }
    }
}
