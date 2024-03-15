using Microsoft.EntityFrameworkCore;
using Sales.Domain.Repository;
using Sales.Infrastructure.Context;

namespace Sales.Infrastructure.core
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SalesContext context;
        private readonly DbSet<TEntity> DbEntities;
        protected BaseRepository(SalesContext context)
        {
            this.context = context;
            this.DbEntities = context.Set<TEntity>();
        }
        public virtual bool Exists(Func<TEntity, bool> filter)
        {
            return DbEntities.Any(filter);
        }

        public virtual List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return DbEntities.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return DbEntities.ToList();
        }

        public virtual TEntity GetEntity(int Id)
        {
            return DbEntities.Find(Id)!;
        }
        public virtual void Remuve(TEntity entity)
        {
            DbEntities.Update(entity);
            this.context.SaveChanges();
        }
        public virtual void Save(TEntity entity)
        {
            DbEntities.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DbEntities.Update(entity);
            context.SaveChanges();
        }
    }
}
