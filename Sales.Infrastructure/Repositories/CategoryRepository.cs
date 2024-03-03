using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Context;
using Sales.Infrastructure.Core;
using Sales.Infrastructure.Exceptions;
using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly SalesContext context;
        private readonly Interfaces.ILogger<CategoryRepository> logger;

        public CategoryRepository(SalesContext context, Interfaces.ILogger<CategoryRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public override List<Category> GetEntities()
        {

            return base.GetEntities().Where(ca => !ca.Eliminado).ToList();
        }

        public override void Update(Category entity)
        {
            try
            {
                var CategoryToUpdate = this.GetEntity(entity.Id);

                CategoryToUpdate.Id = entity.Id;
                CategoryToUpdate.Descripcion = entity.Descripcion;
                CategoryToUpdate.IdUsuarioMod = entity.IdUsuarioMod;
                CategoryToUpdate.FechaMod = entity.FechaMod;

                context.Categoria.Update(CategoryToUpdate);
                context.SaveChanges();
            }
            catch (CategoryException exc)
            {
                logger.LogError(message: "Error al obtener la categoria.", exc);
            }
        }

        public override void Save(Category entity)
        {
            try
            {
                if (context.Categoria.Any(ca => ca.Id == entity.Id))
                    throw new CategoryException("La categoria se encuentra registrada.");

                context.Categoria.Add(entity);
                this.context.SaveChanges();
            }
            catch (CategoryException exc)
            {

                logger.LogError("No fue posible guardar la categoria", exc); ;
            }
        }

        public override void Remove(Category entity)
        {
            try
            {
                var CategoryToRemove = this.GetEntity(entity.Id);

                CategoryToRemove.Eliminado = true;
                CategoryToRemove.FechaElimino = entity.FechaElimino;
                CategoryToRemove.IdUsuarioElimino = entity.IdUsuarioElimino;

                context.Categoria.Update(CategoryToRemove);
                context.SaveChanges();
            }
            catch (CategoryException exc)
            {

                logger.LogError("No fue posible eliminar la categoria", exc);
            }
        }
    }
}