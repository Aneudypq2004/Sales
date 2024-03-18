using Sales.Application.Contracts;
//using Sales.Infrastructure.Core;
using Sales.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Sales.Application.Dtos;

namespace Sales.Application.Core
{
    public abstract class BaseService<TGetModel>
    {
       /* public ServiceResult<List<TModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<TModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<TModel> Remove(TDtoRemove dtoRemove)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<TModel> Save(TDtoAdd dtoAdd)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<TModel> Update(TDtoUpdate dtoUpdate)
        {
            throw new NotImplementedException();
        }*/
    }
}
