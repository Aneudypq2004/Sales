using Microsoft.Extensions.Logging;
using Sales.Application.Contract;
using Sales.Application.Core;
using Sales.Application.Dtos.Category;
using Sales.Application.Dtos.Enums;
using Sales.Application.Models.Category;
using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Interfaces;

namespace Sales.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ILogger<CategoryService> logger;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ILogger<CategoryService> logger,
                                  ICategoryRepository categoryRepository)
        {
            this.logger = logger;
            this.categoryRepository = categoryRepository;
        }

        public ServiceResult<List<CategoryGetModel>> GetAll()
        {
            ServiceResult<List<CategoryGetModel>> result = new ServiceResult<List<CategoryGetModel>>();

            try
            {
                result.Data = categoryRepository.GetEntities().Select(cd => new CategoryGetModel
                {
                    Id = cd.Id,
                    Descripcion = cd.Descripcion,
                    FechaRegistro = cd.FechaRegistro
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo las categorias.";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<CategoryGetModel> GetById(int id)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {
                var category = categoryRepository.GetEntity(id);

                result.Data = new CategoryGetModel()
                {
                    Id = category.Id,
                    Descripcion = category.Descripcion,
                    FechaRegistro = category.FechaRegistro
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la categoria.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<CategoryGetModel> Save(CategoryAddDto addDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {
                var resultIsValid = IsValid(addDto, DtoAction.Save);

                if (!resultIsValid.Success)
                {
                    result.Success = resultIsValid.Success;
                    result.Message = resultIsValid.Message;
                    return result;
                }

                categoryRepository.Save(new Category()
                {
                    Descripcion = addDto.Descripcion,
                    FechaRegistro = addDto.ChangeDate,
                    IdUsuarioCreacion = addDto.UserId,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la categoria.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<CategoryGetModel> Update(CategoryUpdateDto updateDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {
                var resultIsValid = IsValid(updateDto, DtoAction.Update);

                if (!resultIsValid.Success)
                {
                    result.Success = resultIsValid.Success;
                    result.Message = resultIsValid.Message;
                    return result;
                }

                categoryRepository.Update(new Category()
                {
                    Id = updateDto.Id,
                    Descripcion = updateDto.Descripcion,
                    FechaMod = updateDto.ChangeDate,
                    IdUsuarioMod = updateDto.UserId,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando la categoría.";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<CategoryGetModel> Remove(CategoryRemoveDto removeDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {
                var category = categoryRepository.GetEntity(removeDto.Id);

                if (category == null)
                {
                    result.Success = false;
                    result.Message = "Categoría no encontrada.";
                    return result;
                }

                categoryRepository.Remove(new Category()
                {
                    Id = removeDto.Id,
                    FechaElimino = removeDto.ChangeDate,
                    IdUsuarioElimino = removeDto.UserId
                });

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando la categoría.";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        private ServiceResult<string> IsValid(CategoryDtoBase categoryDtoBase, DtoAction action)
        {
            ServiceResult<string> result = new ServiceResult<string>();

            if (string.IsNullOrEmpty(categoryDtoBase.Descripcion))
            {
                result.Success = false;
                result.Message = "La categoría es requerida.";
                return result;
            }

            if (categoryDtoBase.Descripcion?.Length >= 50)
            {
                result.Success = false;
                result.Message = "La descripción de la categoría debe tener 50 caracteres o menos.";
                return result;
            }

            if (action == DtoAction.Save)
            {
                if (categoryRepository.Exists(ca => ca.Descripcion == categoryDtoBase.Descripcion))
                {
                    result.Success = false;
                    result.Message = $"La descripción de la categoría {categoryDtoBase.Descripcion} ya existe.";
                    return result;
                }
            }

            return result;

        }
    }
}
