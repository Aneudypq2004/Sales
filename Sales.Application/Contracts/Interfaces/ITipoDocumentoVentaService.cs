using Sales.Application.Dtos.TipoDocumentoVenta;
using Sales.Application.Models;

namespace Sales.Application.Contracts.Interfaces
{
    public interface ITipoDocumentoVentaService : IBaseService<TipoDocumentoVentaAddDto, TipoDocumentoVentaUpdateDto, TipoDocumentoVentaRemoveDto, TipoDocumentoVentaGetModel>
    {
    }
}
