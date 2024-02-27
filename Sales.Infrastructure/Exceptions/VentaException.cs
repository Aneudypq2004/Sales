

using Sales.Infrastructure.Core;

namespace Sales.Infrastructure.Exceptions
{
    
    public class VentaException : BaseException
    {
        public VentaException(string message) : base(message)
        {
        }
    }
}
