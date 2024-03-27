using Microsoft.Extensions.Logging;
using Sales.Application.Contracts.Interfaces;
using Sales.Application.Core;
using Sales.Application.Dtos.Enum;
using Sales.Application.Dtos.TipoDocumentoVenta;
using Sales.Application.Models;
using Sales.Domain.Entities.ModuloVentas;
using Sales.Infrastructure.Inteface;

namespace Sales.Application.Service
{
    public class TipoDocumentoVentaService : ITipoDocumentoVentaService
    {
        private readonly ILogger<TipoDocumentoVentaService> logger;
        private readonly ITipoDocumentoVentaRepository tipoDocumentoVentaRepository;

        public TipoDocumentoVentaService(ILogger<TipoDocumentoVentaService> logger,ITipoDocumentoVentaRepository tipoDocumentoVentaRepository)
        {
            this.logger = logger;
            this.tipoDocumentoVentaRepository = tipoDocumentoVentaRepository;
        }
        public ServiceResult<List<TipoDocumentoVentaGetModel>> GetAll()
        {
            ServiceResult<List<TipoDocumentoVentaGetModel>> result = new();

            try
            {
                result.Data = this.tipoDocumentoVentaRepository.GetEntities().Select(tdv => new TipoDocumentoVentaGetModel()
                {
                    Id = tdv.Id,
                    Descripcion = tdv.Descripcion,
                    EsActivo = tdv.EsActivo,
                    FechaRegistro = tdv.FechaRegistro,
                    IdUsuarioCreacion = tdv.IdUsuarioCreacion
                }).ToList();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el tipo de documento de venta.";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;


        }

        public ServiceResult<TipoDocumentoVentaGetModel> GetById(int id)
        {

            ServiceResult<TipoDocumentoVentaGetModel> result = new();

            try
            {
                var tipoDocumentoVenta = this.tipoDocumentoVentaRepository.GetEntity(id);

                result.Data = new TipoDocumentoVentaGetModel()
                {
                    Id = tipoDocumentoVenta!.Id,
                    Descripcion = tipoDocumentoVenta.Descripcion,
                    EsActivo = tipoDocumentoVenta.EsActivo,
                    FechaRegistro = tipoDocumentoVenta.FechaRegistro,
                    Eliminado = tipoDocumentoVenta.Eliminado,
                    IdUsuarioCreacion = tipoDocumentoVenta.IdUsuarioCreacion

                };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el id del tipo de documento de venta.";
                this.logger.LogError(result.Message, ex.ToString());

            }
            return result;
        }

        public ServiceResult<TipoDocumentoVentaGetModel> Remove(TipoDocumentoVentaRemoveDto tipoDocumentoVentaRemoveDto)
        {
            ServiceResult<TipoDocumentoVentaGetModel>result = new();

            try
            {
                this.tipoDocumentoVentaRepository.Remove(new TipoDocumentoVenta()
                {
                    Id = tipoDocumentoVentaRemoveDto!.Id
                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el tipo de documento de venta.";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult<TipoDocumentoVentaGetModel> Save(TipoDocumentoVentaAddDto tipoDocumentoVentaAddDto)
        {
            ServiceResult<TipoDocumentoVentaGetModel> result = new();

            try
            {
                var resultValid = this.IsValid(tipoDocumentoVentaAddDto, DtoAction.Save);

                this.tipoDocumentoVentaRepository.Save(new TipoDocumentoVenta()
                {
                    Id = tipoDocumentoVentaAddDto!.Id,
                    Descripcion = tipoDocumentoVentaAddDto.Descripcion,
                    EsActivo = tipoDocumentoVentaAddDto.EsActivo,
                    FechaRegistro = tipoDocumentoVentaAddDto.FechaRegistro,
                    IdUsuarioCreacion = tipoDocumentoVentaAddDto.IdUsuarioCreacion

                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el tipo de documento de venta";
                this.logger.LogError(result.Message,ex.ToString());
            }
            return result;
        }

        public ServiceResult<TipoDocumentoVentaGetModel> Update(TipoDocumentoVentaUpdateDto tipoDocumentoVentaUpdateDto)
        {
            ServiceResult<TipoDocumentoVentaGetModel > result = new();
            try
            {
                var resultValid = this.IsValid(tipoDocumentoVentaUpdateDto, DtoAction.Update);

                this.tipoDocumentoVentaRepository.Update(new TipoDocumentoVenta()
                {
                    Id = tipoDocumentoVentaUpdateDto!.Id,
                    Descripcion = tipoDocumentoVentaUpdateDto.Descripcion,
                    EsActivo = tipoDocumentoVentaUpdateDto.EsActivo,
                    FechaRegistro = tipoDocumentoVentaUpdateDto.FechaRegistro,
                    Eliminado = tipoDocumentoVentaUpdateDto.Eliminado,
                

                });
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error actualizando el tipo de documento de venta.";
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        private ServiceResult<string> IsValid(TipoDocumentoVentaDtoBase tipoDocumentoVentaDtoBase, DtoAction action)
        {
            ServiceResult<string> result = new ();
            
            if (string.IsNullOrEmpty(tipoDocumentoVentaDtoBase.Descripcion))
            {
                result.Success = false;
                result.Message = "La descripcion de este documento de venta es requerida.";
                return result;
            }
            if (tipoDocumentoVentaDtoBase.Descripcion!.Length > 50)
            {
                result.Success = false;
                result.Message = "La descripcion del tipo de documento de venta debe tener 50 carácteres.";
                return result;
            }

            if (action == DtoAction.Save)
            {
                if (this.tipoDocumentoVentaRepository.Exists(tdv => tdv.Descripcion == tipoDocumentoVentaDtoBase.Descripcion))
                {
                    result.Success = false;
                    result.Message = $"el tipo de documento de venta '{tipoDocumentoVentaDtoBase.Descripcion}' ya existe.";
                    return result;
                }
            }

            if (tipoDocumentoVentaDtoBase.FechaRegistro == null)
            {
                result.Success = false;
                result.Message = "La fecha de registro es requerida.";
                return result;
            }

            return result;
        }
    }
}
