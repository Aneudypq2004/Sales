using Sales.Application.Core;

namespace Sales.Application.Contract
{
    public interface IBaseService<TGetModel, TAddDto, TUpdateDto, TRemoveDto>
    {
        ServiceResult<List<TGetModel>> GetAll();
        ServiceResult<TGetModel> GetById(int id);
        ServiceResult<TGetModel> Save(TAddDto addDto);
        ServiceResult<TGetModel> Update(TUpdateDto updateDto);
        ServiceResult<TGetModel> Remove(TRemoveDto removeDto);
    }
}
