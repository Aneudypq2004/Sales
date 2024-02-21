namespace Sales.Infrastructure.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {
            GuardarLog(message);
       
        }

        private static void GuardarLog(string message)
        {

        }
    }
}
