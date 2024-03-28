using Microsoft.EntityFrameworkCore;
using Sales.Domain.Repository;
using Sales.Infrastructure.Context;

namespace Sales.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SalesContext context;

        private readonly DbSet<TEntity> DbEntity;

        public BaseRepository(SalesContext context)
        {
            this.context = context;
            this.DbEntity = context.Set<TEntity>();
        }

        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return DbEntity.Any(filter);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return DbEntity.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return DbEntity.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return DbEntity.Find(id)!;
        }

        public virtual void Remove(TEntity entity)
        {
            try
            {
                DbEntity.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual void Save(TEntity entity)
        {
            try
            {
                DbEntity.Add(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                DbEntity.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}