using Microsoft.Extensions.Logging;
using Sales.Application.Contracts.Interfaces;
using Sales.Application.Core;
using Sales.Application.Dtos.Enum;
using Sales.Application.Dtos.venta;
using Sales.Application.Models;
using Sales.Domain.Entities;
using Sales.Infrastructure.Inteface;



namespace Sales.Application.Service
{
    public class VentaService : IVentaService
    {
        private readonly ILogger<VentaService> logger;
        private readonly IVentaRepository ventaRepository;

        public VentaService(ILogger<VentaService> logger, IVentaRepository ventaRepository) {
            this.logger = logger;
            this.ventaRepository = ventaRepository;
        }

        public ServiceResult<List<VentaGetModel>> GetAll()
        {
            ServiceResult<List<VentaGetModel>> result = new();
            try
            {
                result.Data = this.ventaRepository.GetEntities().Select(v => new VentaGetModel()
                {
                    Id = v.Id,
                    NombreCliente = v.NombreCliente,
                    SubTotal = v.SubTotal,
                    ImpuestoTotal = v.ImpuestoTotal,
                    Total = v.Total,
                    FechaRegistro = v.FechaRegistro

                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la venta.";
                this.logger.LogError(result.Message, ex.ToString());

            }

            return result;
        }

        public ServiceResult<VentaGetModel> GetById(int id)
        {
            ServiceResult<VentaGetModel> result = new();

            try
            {
                var venta = this.ventaRepository.GetEntity(id);

                result.Data = new VentaGetModel()
                {
                    Id = venta!.Id,
                    NombreCliente = venta!.NombreCliente,
                    SubTotal = venta.SubTotal,
                    ImpuestoTotal = venta.ImpuestoTotal,
                    Total = venta.Total,
                    FechaRegistro = venta.FechaRegistro,
                    IdUsuarioCreacion = venta.IdUsuarioCreacion
                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo la venta.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public ServiceResult<VentaGetModel> Remove(VentaRemoveDto ventaRemoveDto)
        {
            ServiceResult<VentaGetModel> result = new();

            try
            {
                this.ventaRepository.Remove(new Venta()
                {
                    Id = ventaRemoveDto.Id
                });
            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = "Error removiendo esta venta";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<VentaGetModel> Save(VentaAddDto ventaAddDto)
        {
            ServiceResult<VentaGetModel> result = new();
            try
            {
                var resultValid = this.IsValid(ventaAddDto, DtoAction.Save);

                this.ventaRepository.Save( new Venta()
                {
                    Id = ventaAddDto.Id,
                    NombreCliente = ventaAddDto!.NombreCliente,
                    SubTotal = ventaAddDto.SubTotal,
                    ImpuestoTotal = ventaAddDto.ImpuestoTotal,
                    Total = ventaAddDto.Total,
                    FechaRegistro = ventaAddDto.FechaRegistro,
                    IdUsuarioCreacion = ventaAddDto.IdUsuarioCreacion
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando la venta.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public ServiceResult<VentaGetModel> Update(VentaUpdateDto ventaUpdateDto)
        {
            ServiceResult<VentaGetModel>result = new();

            try
            {
                var resultValid = this.IsValid(ventaUpdateDto, DtoAction.Update);

                this.ventaRepository.Update(new Venta()
                {
                    NombreCliente = ventaUpdateDto!.NombreCliente,
                    SubTotal = ventaUpdateDto.SubTotal,
                    ImpuestoTotal = ventaUpdateDto.ImpuestoTotal,
                    Total = ventaUpdateDto.Total
                });
            }
            catch(Exception ex) 
            {
                result.Success = false;
                result.Message = "Error Actualizando la venta";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        private ServiceResult<string> IsValid(VentaDtoBase ventaDtoBase, DtoAction action)
        {
            ServiceResult <string> result = new();

            if (string.IsNullOrEmpty(ventaDtoBase.Numeroventa))
            {
                result.Success = false;
                result.Message = "la venta es requerida";
                return result;
            }
            if (ventaDtoBase.Numeroventa!.Length > 6)
            {
                result.Success = false;
                result.Message = "El número de esta venta debe tener 6 carácteres.";
                return result;
            }
            if (string.IsNullOrEmpty(ventaDtoBase.NombreCliente))
            {
                result.Success = false;
                result.Message = "El nombre del cliente es requerido";
                return result;
            }
            if (ventaDtoBase.NombreCliente!.Length > 20)
            {
                result.Success = false;
                result.Message = "El Nombre del cliente debe tener 20 carácteres.";
                return result;
            }
            if (action == DtoAction.Save)
            {
                if (this.ventaRepository.Exists(v => v.NumeroVenta == ventaDtoBase.Numeroventa))
                {
                    result.Success = false;
                    result.Message = $"el número de venta '{ventaDtoBase.Numeroventa}' ya existe.";
                    return result;
                }
            }

            if (ventaDtoBase.FechaRegistro == null)
            {
                result.Success = false;
                result.Message = "La fecha de registro es requerida.";
                return result;
            }

            return result;
        }
    }
}
