using Microsoft.Extensions.Logging;
using Sales.Application.Dtos.Category;
using Sales.Application.Models.Category;
using Sales.Application.Contract;
using Sales.Application.Core;
using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Interfaces;

namespace Sales.Application.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ILogger<CategoryService> logger;
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ILogger<CategoryService> logger,
                               ICategoryRepository categoryRepository) : base (logger)
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
                        Description = cd.Descripcion,
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
                    Description = category.Descripcion,
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


        public ServiceResult<CategoryGetModel> Save(CategoryAddDto categoryAddDto)
        {
            ServiceResult<CategoryGetModel> result = new ServiceResult<CategoryGetModel>();

            try
            {
                if (categoryAddDto.Descripcion?.Length >= 50)
                {
                    result.Success = false;
                    result.Message = "La descripción de la categoria debe tener 50 carácteres o menos.";
                    return result;
                }

                if (categoryRepository.Exists(ca => ca.Descripcion == categoryAddDto?.Descripcion))
                {
                    result.Success = false;
                    result.Message = $"La descripción de la categoria { categoryAddDto?.Descripcion } ya existe.";
                    return result;
                }

                categoryRepository.Save(new Category()
                {
                    Descripcion = categoryAddDto.Descripcion,
                    FechaRegistro = categoryAddDto.ChangeDate,
                    IdUsuarioCreacion = categoryAddDto.UserId,
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
                var category = categoryRepository.GetEntity(updateDto.Id);
                if (category == null)
                {
                    result.Success = false;
                    result.Message = "Categoría no encontrada.";
                    return result;
                }

                if (updateDto.Descripcion?.Length >= 50)
                {
                    result.Success = false;
                    result.Message = "La descripción de la categoría debe tener 50 caracteres o menos.";
                    return result;
                }

                if (categoryRepository.Exists(ca => ca.Descripcion == updateDto.Descripcion && ca.Id != updateDto.Id))
                {
                    result.Success = false;
                    result.Message = $"La descripción de la categoría {updateDto.Descripcion} ya existe.";
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

         
 
    }
}
