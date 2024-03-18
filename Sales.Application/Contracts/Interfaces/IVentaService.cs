using Sales.Application.Dtos.venta;
using Sales.Application.Models;

namespace Sales.Application.Contracts.Interfaces
{
    public interface IVentaService : IBaseService<VentaAddDto, VentaUpdateDto, VentaRemoveDto, VentaGetModel>
    {

    }
}
