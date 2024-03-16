using Microsoft.EntityFrameworkCore;
using Sales.Domain.Repository;
using Sales.Infrastructure.Context;

namespace Sales.Infrastructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly SalesContext context;
        private readonly DbSet<TEntity> DBEntity;

        public BaseRepository(SalesContext context) 
        {
            this.context = context;

            DBEntity = context.Set<TEntity>();
        }

        public bool Exists(Func<TEntity, bool> condicion)
        {
            return DBEntity.Any(condicion);
        }

        public List<TEntity> FindAll(Func<TEntity, bool> filter)
        {
            return DBEntity.Where(filter).ToList();
        }

        public virtual List<TEntity> GetEntities()
        {
            return DBEntity.ToList();
        }

        public virtual TEntity? GetEntity(int Id)
        {
            return DBEntity.Find(Id);
        }

        public virtual void Remove(TEntity entity)
        {
            DBEntity.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Save(TEntity entity)
        {
            DBEntity.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            DBEntity.Update(entity);
            context.SaveChanges();
        }
    }
}

