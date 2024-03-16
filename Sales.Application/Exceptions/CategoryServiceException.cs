

namespace Sales.Application.Exceptions
{
    public class CategoryServiceException : Exception
    {
        public CategoryServiceException(string message) : base(message) 
        {
            GuardarLog(message);
        }

        void GuardarLog(string message)
        {

        }
    }
}
