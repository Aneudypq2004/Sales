
using Sales.Infrastructure.Core;

namespace Sales.Infrastructure.Exceptions
{
    public class TipoDocumentoVentaException : BaseException
    {
        public TipoDocumentoVentaException(string message) : base(message)
        {
        }
    }
}
