using Sales.Application.Core;

namespace Sales.Application.Contracts
{
    public interface IBaseService<TDtoAdd, TDtoUpdate, TDtoRemove,TModel> where TModel : class
    {
        ServiceResult<List<TModel>> GetAll();

        ServiceResult<TModel> GetById(int id);

        ServiceResult<TModel> Save(TDtoAdd dtoAdd);

        ServiceResult<TModel> Remove(TDtoRemove dtoRemove);

        ServiceResult<TModel> Update(TDtoUpdate dtoUpdate);
    }
}
