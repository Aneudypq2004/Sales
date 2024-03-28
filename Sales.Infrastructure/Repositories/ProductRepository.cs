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

        public ProductRepository(SalesContext context, ILogger<ProductRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;

        }

        public override List<Product> GetEntities()
        {
            return base.GetEntities().Where(pro => !pro.Eliminado).ToList();
        }

        public override Product GetEntity(int id)
        {
            return base.GetEntity(id);
        }
        
        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            List<ProductModel> products = new List<ProductModel>();
            try
            {
                products = (from pro in this.context.Producto
                             join ca in context.Categoria! on pro.IdCategoria equals ca.Id
                             where pro.IdCategoria == categoryId
                             select new ProductModel()
                             {
                                 Id = pro.Id,
                                 IdCategoria = ca.Id,
                                 Marca = pro.Marca,
                                 Descripcion = pro.Descripcion,
                                 Stock = pro.Stock,
                                 UrlImagen = pro.UrlImagen,
                                 NombreImagen = pro.NombreImagen,
                                 Precio = pro.Precio,
                             }).ToList();
            }
            catch (Exception ex)
            {

                logger.LogError("Error obteniendo los productos", ex);
            }

            return products;
        }

        public override void Update(Product entity)
        {
            try
            {
                var ProductToUpdate = this.GetEntity(entity.Id);
                ProductToUpdate.Marca = entity.Marca;
                ProductToUpdate.Descripcion = entity.Descripcion;
                ProductToUpdate.Stock = entity.Stock;
                ProductToUpdate.IdCategoria = entity.IdCategoria;
                ProductToUpdate.UrlImagen = entity.UrlImagen;
                ProductToUpdate.NombreImagen = entity.NombreImagen;
                ProductToUpdate.Precio = entity.Precio;
                ProductToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                ProductToUpdate.FechaMod = DateTime.Now;

                context.Producto!.Update(ProductToUpdate);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError("Error actualizando el producto", ex);
            }

        }

        public override void Save(Product entity)
        {
            try
            {
                entity.FechaRegistro = DateTime.Now;
                context.Producto!.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                logger.LogError("Error guardando el producto", ex); ;
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

                logger.LogError("Error eliminando el producto", ex);
            }
        }
    }
}