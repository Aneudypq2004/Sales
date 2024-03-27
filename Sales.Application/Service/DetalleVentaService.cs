using Microsoft.Extensions.Logging;
using Sales.Application.Contracts.Interfaces;
using Sales.Application.Core;
using Sales.Application.Dtos.DetalleVenta;
using Sales.Application.Dtos.Enum;
using Sales.Application.Models;
using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Inteface;

namespace Sales.Application.Service
{
    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly ILogger<DetalleVentaService> logger;
        private readonly IDetalleVentaRepository detalleVentaRepository;
        public DetalleVentaService(ILogger<DetalleVentaService> logger, IDetalleVentaRepository detalleVentaRepository) { 
            
            this.logger = logger;
            this.detalleVentaRepository = detalleVentaRepository;
        }
        public ServiceResult<List<DetalleVentaGetModel>> GetAll()
        {
            ServiceResult<List<DetalleVentaGetModel>> result = new();

            try
            {
                result.Data = this.detalleVentaRepository.GetEntities().Select(dv => new DetalleVentaGetModel()
                {
                    Id = dv.Id,
                    IdVenta = dv.IdVenta,
                    IdProducto = dv.IdProducto,
                    MarcaProducto = dv.MarcaProducto,
                    DescripcionProducto = dv.DescripcionProducto,
                    CategoriaProducto = dv.CategoriaProducto,
                    Cantidad = dv.Cantidad,
                    Precio = dv.Precio,
                    Total = dv.Total,

                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el detalle de venta.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result; 
        }

        public ServiceResult<DetalleVentaGetModel> GetById(int id)
        {
            ServiceResult<DetalleVentaGetModel> result = new();

            try
            {
                var detalleVenta = this.detalleVentaRepository.GetEntity(id);
                result.Data = new DetalleVentaGetModel()
                {
                    Id = detalleVenta!.Id,
                    IdVenta = detalleVenta.IdVenta,
                    IdProducto = detalleVenta.IdProducto,
                    MarcaProducto = detalleVenta.MarcaProducto,
                    DescripcionProducto = detalleVenta.DescripcionProducto,
                    CategoriaProducto = detalleVenta.CategoriaProducto,
                    Cantidad = detalleVenta.Cantidad,
                    Precio = detalleVenta.Precio,
                    Total = detalleVenta.Total,

                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el detalle de venta";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult<DetalleVentaGetModel> Remove(DetalleVentaRemoveDto detalleVentaRemoveDto)
        {
            ServiceResult<DetalleVentaGetModel> result = new();

            try
            {
                this.detalleVentaRepository.Remove(new DetalleVenta(){
                    Id = detalleVentaRemoveDto.Id
                });
            }
            catch(Exception ex)
            {
                result.Success = false;
                result.Message = "Error removiendo el detalle de venta";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<DetalleVentaGetModel> Save(DetalleVentaAddDto detalleVentaAddDto)
        {
            ServiceResult<DetalleVentaGetModel> result = new();
            
            try
            {
                var resultValid = this.IsValid(detalleVentaAddDto, DtoAction.Save);

                this.detalleVentaRepository.Save(new DetalleVenta()
                {
                    Id = detalleVentaAddDto!.Id,
                    MarcaProducto = detalleVentaAddDto.MarcaProducto,
                    DescripcionProducto = detalleVentaAddDto.DescripcionProducto,
                    CategoriaProducto = detalleVentaAddDto.CategoriaProducto,
                    Cantidad = detalleVentaAddDto.Cantidad,
                    Precio = detalleVentaAddDto.Precio,
                    Total = detalleVentaAddDto.Total,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el detalle de venta.";
                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }

        public ServiceResult<DetalleVentaGetModel> Update(DetalleVentaUpdateDto detalleVentaUpdateDto)
        {
            ServiceResult<DetalleVentaGetModel> result = new();

            try
            {
                var resultValid = this.IsValid(detalleVentaUpdateDto, DtoAction.Save);
                this.detalleVentaRepository.Save(new DetalleVenta()
                {
                    Id = detalleVentaUpdateDto!.Id,
                    MarcaProducto = detalleVentaUpdateDto.MarcaProducto,
                    DescripcionProducto = detalleVentaUpdateDto.DescripcionProducto,
                    CategoriaProducto = detalleVentaUpdateDto.CategoriaProducto,
                    Cantidad = detalleVentaUpdateDto.Cantidad,
                    Precio = detalleVentaUpdateDto.Precio,
                    Total = detalleVentaUpdateDto.Total,
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el detalle de venta.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        private ServiceResult<string> IsValid(DetalleventaDtoBase detalleventaDtoBase, DtoAction action)
        {
            ServiceResult<string> result = new();

            if (string.IsNullOrEmpty(detalleventaDtoBase.MarcaProducto))
            {
                result.Success = false;
                result.Message = "la marca del producto es requerida";
                return result;
            }

            if (detalleventaDtoBase.MarcaProducto.Length > 100)
            {
                result.Success = false;
                result.Message = "la marca del producto debe  tener 100 carácteres.";
                return result;
            }

            if (string.IsNullOrEmpty(detalleventaDtoBase.DescripcionProducto))
            {
                result.Success = false;
                result.Message = "la Descripcion del producto es requerida";
                return result;
            }
            if (detalleventaDtoBase.DescripcionProducto.Length > 100)
            {
                result.Success = false;
                result.Message = "la descripción del producto debe  tener 100 carácteres.";
                return result;
            }

            if (detalleventaDtoBase.CategoriaProducto!.Length > 100)
            {
                result.Success = false;
                result.Message = "la categoría del producto debe  tener 100 carácteres.";
                return result;
            }
            if (string.IsNullOrEmpty(detalleventaDtoBase.CategoriaProducto))
            {
                result.Success = false;
                result.Message = "la categoría del productors requerida.";
                return result;
            }

            if (action == DtoAction.Save)
            {
                if (this.detalleVentaRepository.Exists(dv => dv.DescripcionProducto == detalleventaDtoBase.DescripcionProducto))
                {
                    result.Success = false;
                    result.Message = $"el tipo de documento de venta '{detalleventaDtoBase.DescripcionProducto}' ya existe.";
                    return result;
                }
            }

            return result;
        }
    }
}
