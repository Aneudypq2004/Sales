using Sales.Application.Contracts;
//using Sales.Infrastructure.Core;
using Sales.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Sales.Application.Core
{
    public abstract class BaseService<TGetModel> : IBaseService<TGetModel> where TGetModel : class
    {
        private SalesContext context;
        private readonly DbSet<TGetModel> DbEntity;

        //private readonly BaseRepository<TEntity> repository;

        public BaseService(SalesContext context)
        {
            this.context = context;
            DbEntity = context.Set<TGetModel>();
        }

        ServiceResult<List<TGetModel>> IBaseService<TGetModel>.GetAll()
        {
            throw new NotImplementedException();
        }

        ServiceResult<TGetModel> IBaseService<TGetModel>.GetById(dynamic id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<TGetModel> Save(TGetModel entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<int> Remove(TGetModel entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<int> Update(TGetModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
