using Sales.Application.Core;

namespace Sales.Application.Contracts
{
    public interface IBaseService<TGetModel> where TGetModel : class
    {
        ServiceResult<List<TGetModel>> GetAll();

        ServiceResult<TGetModel> GetById(dynamic id);

        ServiceResult<TGetModel> Save(TGetModel entity);

        ServiceResult<int> Remove(TGetModel entity);

        ServiceResult<int> Update(TGetModel entity);
    }
}
