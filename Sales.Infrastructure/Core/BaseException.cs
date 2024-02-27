

namespace Sales.Infrastructure.Core
{
    public class BaseException: Exception
    {
        public BaseException(string message) : base(message)
        {
            GuardarLog(message);
        }

        public void GuardarLog(string message) 
        {

        }
    }
}
