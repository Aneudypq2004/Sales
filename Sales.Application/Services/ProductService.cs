using Microsoft.Extensions.Logging;
using Sales.Application.Contract;
using Sales.Application.Core;
using Sales.Application.Dtos.Enums;
using Sales.Application.Dtos.Product;
using Sales.Application.Models.Product;
using Sales.Domain.Entities.Production;
using Sales.Infrastructure.Interfaces;

namespace Sales.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;
        private readonly IProductRepository productRepository;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            this.logger = logger;
            this.productRepository = productRepository;
        }

        public ServiceResult<List<ProductGetModel>> GetAll()
        {
            ServiceResult<List<ProductGetModel>> result = new ServiceResult<List<ProductGetModel>>();

            try
            {
                result.Data = productRepository.GetEntities().Select(cd => new ProductGetModel
                {
                    Id = cd.Id,
                    Marca = cd.Marca,
                    Descripcion = cd.Descripcion,
                    IdCategory = cd.IdCategoria,
                    Stock = cd.Stock,
                    UrlImagen = cd.UrlImagen,
                    NombreImagen = cd.NombreImagen,
                    Precio = cd.Precio,
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<ProductGetModel> GetById(int id)
        {
            ServiceResult<ProductGetModel> result = new ServiceResult<ProductGetModel>();

            try
            {
                var product = productRepository.GetEntity(id);

                result.Data = new ProductGetModel()
                {
                    Id = product.Id,
                    Marca = product.Marca,
                    Descripcion = product.Descripcion,
                    IdCategory = product.IdCategoria,
                    Stock = product.Stock,
                    UrlImagen = product.UrlImagen,
                    NombreImagen = product.NombreImagen,
                    Precio = product.Precio
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<ProductGetModel> GetProductsByCategory(int categoryId)
        {
            ServiceResult<ProductGetModel> result = new ServiceResult<ProductGetModel>();

            try
            {
                var product = productRepository.GetEntity(categoryId);

                result.Data = new ProductGetModel()
                {
                    Id = product.Id,
                    Marca = product.Marca,
                    Descripcion = product.Descripcion,
                    IdCategory = product.IdCategoria,
                    Stock = product.Stock,
                    UrlImagen = product.UrlImagen,
                    NombreImagen = product.NombreImagen,
                    Precio = product.Precio
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<ProductGetModel> Save(ProductAddDto addDto)
        {
            ServiceResult<ProductGetModel> result = new ServiceResult<ProductGetModel>();

            try
            {
                var resultIsValid = IsValid(addDto, DtoAction.Save);

                if (!resultIsValid.Success)
                {
                    result.Message = resultIsValid.Message;
                    return result;
                }

                productRepository.Save(new Product()
                {
                    Marca = addDto.Marca,
                    Descripcion = addDto.Descripcion,
                    IdCategoria = addDto.IdCategory,
                    Stock = addDto.Stock,
                    UrlImagen = addDto.UrlImagen,
                    NombreImagen = addDto.NombreImagen,
                    Precio = addDto.Precio,
                    FechaRegistro = addDto.ChangeDate,
                    IdUsuarioCreacion = addDto.UserId
                });
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el producto.";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<ProductGetModel> Update(ProductUpdateDto updateDto)
        {
            ServiceResult<ProductGetModel> result = new ServiceResult<ProductGetModel>();
            try
            {
                var resultIsValid = IsValid(updateDto, DtoAction.Update);

                if (!resultIsValid.Success)
                {
                    result.Message = resultIsValid.Message;
                    return result;
                }

                productRepository.Update(new Product()
                {
                    Id = updateDto.Id,
                    Marca = updateDto.Marca,
                    Descripcion = updateDto.Descripcion,
                    IdCategoria = updateDto.IdCategory,
                    Stock = updateDto.Stock,
                    UrlImagen = updateDto.UrlImagen,
                    NombreImagen = updateDto.NombreImagen,
                    Precio = updateDto.Precio,
                    FechaRegistro = updateDto.ChangeDate,
                    IdUsuarioCreacion = updateDto.UserId,
                });
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando el producto.";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<ProductGetModel> Remove(ProductRemoveDto removeDto)
        {
            var result = new ServiceResult<ProductGetModel>();

            try
            {
                var product = productRepository.GetEntity(removeDto.Id);
                if (product == null)
                {
                    result.Success = false;
                    result.Message = "Producto no encontrado.";
                    return result;
                }

                productRepository.Remove(new Product()
                {
                    Id = removeDto.Id,
                    FechaElimino = removeDto.ChangeDate,
                    IdUsuarioElimino = removeDto.UserId
                });
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el producto.";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        private ServiceResult<string> IsValid(ProductDtoBase productDtoBase, DtoAction action)
        {
            ServiceResult<string> result = new ServiceResult<string>();

            if (productDtoBase.Marca?.Length >= 50)
            {
                result.Success = false;
                result.Message = "La marca del producto debe tener 50 carácteres o menos.";
                return result;
            }

            if (productDtoBase.Descripcion?.Length >= 100)
            {
                result.Success = false;
                result.Message = "La descripción del producto debe tener 100 carácteres o menos.";
                return result;
            }

            if (productDtoBase.UrlImagen?.Length > 500)
            {
                result.Success = false;
                result.Message = "La URL de la imagen del producto debe tener 500 caracteres o menos.";
                return result;
            }

            if (productDtoBase.NombreImagen?.Length > 100)
            {
                result.Success = false;
                result.Message = "El nombre de la imagen del producto debe tener 100 caracteres o menos.";
                return result;
            }

            if (productDtoBase.Precio <= 0 || productDtoBase.Precio >= 99999999)
            {
                result.Success = false;
                result.Message = "El precio del producto debe ser mayor que 0 y menos que 1000000.";
                return result;
            }

            if (action == DtoAction.Save)
            {
                if (productRepository.Exists(pro => pro.Descripcion == productDtoBase.Descripcion))
                {
                    result.Success = false;
                    result.Message = $"La descripción del producto {productDtoBase.Descripcion} ya existe.";
                    return result;
                }
            }

            return result;
        }
    }
}