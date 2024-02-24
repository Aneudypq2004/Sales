
using Sales.Infrastructure.Core;

namespace Sales.Infrastructure.Exceptions
{
    // Needs a review to confirm is good
    public class VentaException : IBaseException
    {   

        public VentaException(string message)
        {
            GuardarLog(message);
        }
        public void GuardarLog(string message)
        {

        }
    }
}
