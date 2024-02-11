
namespace Sales.Infrastructure.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException(string message) : base(message)
        {
            GuardarLog(message);
        }

        void GuardarLog(string message)
        {

        }
    }
}
