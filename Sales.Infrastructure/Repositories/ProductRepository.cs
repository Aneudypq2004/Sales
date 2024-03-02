using Microsoft.Extensions.Logging;
using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;
using Sales.Infrastructure.Model;

namespace Sales.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly SalesContext context;
        private readonly ILogger<ProductRepository> logger;

        protected ProductRepository(SalesContext context, ILogger<ProductRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;

        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                var query = (from pro in this.context.Producto
                            join ca in context.Categoria on pro.IdCategoria equals ca.Id
                            where pro.IdCategoria == categoryId
                            select new ProductModel() {
                            IdCategory = ca.Id,
                            CodigoDeBarra = pro.CodigoBarra,
                            Marca = pro.Marca,
                            Descripcion = pro.Descripcion,
                            Stock = pro.Stock,
                            UrlImagen = pro.UrlImagen,
                            NombreImagen = pro.NombreImagen,
                            Precio = pro.Precio
                            }).ToList();
            }
            catch (Exception ex)
            {

                logger.LogError("Error obteniendo los productos", ex.ToString());
            }

            return products;
        }


        public override List<Product> GetEntities()
        {
            return base.GetEntities().Where(pro => !pro.Eliminado).ToList();
        }

        public override void Update(Product entity)
        {
            try
            {
                var ProductToUpdate = this.GetEntity(entity.Id);

                ProductToUpdate.Id = entity.Id;
                ProductToUpdate.Descripcion = entity.Descripcion;
                ProductToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                ProductToUpdate.FechaMod = entity.FechaMod;

                context.Producto.Update(ProductToUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error actualizando el producto", ex.ToString());
            }
        }

        public override void Save(Product entity)
        {
            try
            {
                if (context.Producto.Any(pro => pro.Id == entity.Id))
                    throw new CategoryException("El producto encuentra registrada.");

                context.Producto.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                logger.LogError("Error guardando el producto", ex.ToString()); ;
            }
        }

        public override void Remove(Product entity)
        {
            try
            {
                var ProductToRemove = this.GetEntity(entity.Id);

                ProductToRemove.Eliminado = true;
                ProductToRemove.FechaElimino = entity.FechaElimino;
                ProductToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;

                context.Producto.Update(ProductToRemove);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                logger.LogError("Error eliminando el producto", ex.ToString());
            }
        }
    }
}
