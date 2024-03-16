using Microsoft.Extensions.Logging;
using Sales.Api.Dtos.Product;
using Sales.Api.Models.Product;
using Sales.Application.Contract;
using Sales.Application.Core;
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
                var query = productRepository.GetEntities().Select(cd => new ProductGetModel
                {
                    Id = cd.Id,
                    Marca = cd.Marca,
                    Descripcion = cd.Descripcion,
                    IdCategory = cd.IdCategoria,
                    Stock = cd.Stock,
                    UrlImagen = cd.UrlImagen,
                    NombreImagen = cd.NombreImagen,
                    Precio = cd.Precio,
                    FechaRegistro = cd.FechaRegistro,
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
            ServiceResult <ProductGetModel> result = new ServiceResult<ProductGetModel>();

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
                    Precio = product.Precio,
                    FechaRegistro = product.FechaRegistro,
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

        public ServiceResult<List<ProductGetModel>> GetProductsByCategory(int categoryId)
        {
            ServiceResult<List<ProductGetModel>> result = new ServiceResult<List<ProductGetModel>>();

            try
            {
                var products = productRepository.GetProductsByCategory(categoryId).Select(pro => new ProductGetModel
                { 
                    Id = pro.Id,
                    Marca = pro.Marca,
                    Descripcion = pro.Descripcion,
                    IdCategory = pro.IdCategory,
                    Stock = pro.Stock,
                    UrlImagen = pro.UrlImagen,
                    NombreImagen = pro.NombreImagen,
                    Precio = pro.Precio,
                    FechaRegistro = pro.FechaRegistro
                }).ToList();

                result.Data = products;
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
            ServiceResult<List<ProductGetModel>> result = new ServiceResult<List<ProductGetModel>>();

            try
            {
                if (addDto.Marca?.Length >= 50)
                {
                    result.Success = false;
                    result.Message = "La marca del producto debe tener 50 carácteres o menos.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (addDto.Descripcion?.Length >= 100)
                {
                    result.Success = false;
                    result.Message = "La descripción del producto debe tener 100 carácteres o menos.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (addDto.UrlImagen?.Length > 500)
                {
                    result.Success = false;
                    result.Message = "La URL de la imagen del producto debe tener 500 caracteres o menos.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (addDto.NombreImagen?.Length > 100)
                {
                    result.Success = false;
                    result.Message = "El nombre de la imagen del producto debe tener 100 caracteres o menos.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (addDto.Precio <= 0 || addDto.Precio >= 99999999)
                {
                    result.Success = false;
                    result.Message = "El precio del producto debe ser mayor que 0 y menos que 1000000.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (productRepository.Exists(ca => ca.Descripcion == addDto?.Descripcion))
                {
                    result.Success = false;
                    result.Message = $"La descripción del producto {addDto?.Descripcion} ya existe.";
                    return new ServiceResult<ProductGetModel>();
                }

                    productRepository.Save(new Domain.Entities.Production.Product()
                {
                    FechaRegistro = addDto.ChangeDate,
                    IdUsuarioCreacion = addDto.UserId,
                    Id = addDto.Id,
                    Marca = addDto.Marca,
                    Descripcion = addDto.Descripcion,
                    IdCategoria = addDto.IdCategory,
                    Stock = addDto.Stock,
                    UrlImagen = addDto.UrlImagen,
                    NombreImagen = addDto.NombreImagen,
                    Precio = addDto.Precio
                });
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el producto.";
                logger.LogError(result.Message, ex.ToString());
            }

            return new ServiceResult<ProductGetModel>();
        }

        public ServiceResult<ProductGetModel> Update(ProductUpdateDto updateDto)
        {
            ServiceResult<ProductGetModel> result = new ServiceResult<ProductGetModel>();
            try
            {
                if (updateDto.Marca?.Length >= 50)
                {
                    result.Success = false;
                    result.Message = "La marca del producto debe tener 50 carácteres o menos.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (updateDto.Descripcion?.Length >= 100)
                {
                    result.Success = false;
                    result.Message = "La descripción del producto debe tener 100 carácteres o menos.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (updateDto.UrlImagen?.Length > 500)
                {
                    result.Success = false;
                    result.Message = "La URL de la imagen del producto debe tener 500 caracteres o menos.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (updateDto.NombreImagen?.Length > 100)
                {
                    result.Success = false;
                    result.Message = "El nombre de la imagen del producto debe tener 100 caracteres o menos.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (updateDto.Precio <= 0 || updateDto.Precio >= 99999999)
                {
                    result.Success = false;
                    result.Message = "El precio del producto debe ser mayor que 0 y menos que 1000000.";
                    return new ServiceResult<ProductGetModel>();
                }

                if (productRepository.Exists(ca => ca.Descripcion == updateDto.Descripcion && ca.Id != updateDto.Id))
                {
                    result.Success = false;
                    result.Message = $"La descripción del producto {updateDto.Descripcion} ya existe.";
                    return result;
                }

                productRepository.Update(new Domain.Entities.Production.Product()
                {
                    FechaRegistro = updateDto.ChangeDate,
                    IdUsuarioCreacion = updateDto.UserId,
                    Id = updateDto.Id,
                    Marca = updateDto.Marca,
                    Descripcion = updateDto.Descripcion,
                    IdCategoria = updateDto.IdCategory,
                    Stock = updateDto.Stock,
                    UrlImagen = updateDto.UrlImagen,
                    NombreImagen = updateDto.NombreImagen,
                    Precio = updateDto.Precio
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

                productRepository.Remove(product);
            }

            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error eliminando el producto.";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

    }
}
