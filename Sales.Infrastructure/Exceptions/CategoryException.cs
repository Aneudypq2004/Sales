
namespace Sales.Infrastructure.Exceptions
{
    public class CategoryException : Exception
    {
        public CategoryException(string message) : base(message) 
        {
            GuardarLog(message);
        }

        void GuardarLog(string message)
        {

        }
    }
}
