using Sales.Application.Contracts;
using Sales.Application.Core;
using Sales.Domain.Entities.negocios;
using Sales.Infrastructure.Context;

namespace Sales.Application.Services
{
    public class NumeroCorrelativoService : BaseService<NumeroCorrelativo>,INumeroCorrelativoServices
    {
        public NumeroCorrelativoService(SalesContext context) :base(context)
        {
            
        }
    }
}
