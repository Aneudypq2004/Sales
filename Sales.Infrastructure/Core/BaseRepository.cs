
using Microsoft.EntityFrameworkCore;
using Sales.Domain.Repository;
using Sales.Infrastructure.Context;

namespace Sales.Infrastructure.Core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SalesContext context;

        private readonly DbSet<TEntity> DbEntity;

        public BaseRepository(SalesContext context)
        {

            this.context = context;
            DbEntity = context.Set<TEntity>();

        }

        public virtual List<TEntity>GetEntities()
        {
            return DbEntity.ToList();
        }

        public virtual bool Exists(Func<TEntity, bool> condition)
        {
            return DbEntity.Any(condition);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return DbEntity.Where(filter).ToList();
        }

        public virtual TEntity? GetEntity(int Id)
        {
            return DbEntity.Find(Id);
        }

        public virtual void Save(TEntity entity)
        {
            try
            {
                DbEntity.Add(entity);
                context.SaveChanges();
            }
            catch (Exception) {

                throw;

            }
            
        }

        public virtual void Remove(TEntity entity)
        {
            DbEntity.Remove(entity);
            context.SaveChanges();
        }
        public virtual void Update(TEntity entity)
        {
            DbEntity.Update(entity);
            context.SaveChanges();
        }

    }
}
