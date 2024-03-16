
namespace Sales.Application.Exceptions
{
    public class ProductServiceException : Exception
    {
        public ProductServiceException(string message) : base(message)
        {
            GuardarLog(message);
        }

        void GuardarLog(string message)
        {

        }
    }
}
