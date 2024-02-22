namespace Sales.Infrastructure.Exceptions
{
    public class RolException : Exception
    {
        public RolException(string message) : base(message)
        {
            GuardarLog(message);
        }

        private void GuardarLog(string message)
        {

        }
    }
}
