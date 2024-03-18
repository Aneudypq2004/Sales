using Sales.Application.Dtos.DetalleVenta;
using Sales.Application.Models;

namespace Sales.Application.Contracts.Interfaces
{
    public interface IDetalleVentaService: IBaseService<DetalleVentaAddDto,DetalleVentaUpdateDto,DetalleVentaRemoveDto,DetalleVentaGetModel>
    {

    }
}
