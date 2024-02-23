namespace Sales.Infrastructure.Exceptions
{
    public class ConfigurationException : Exception
    {
        public ConfigurationException(string message) : base(message)
        {

            GuardarLog(message);

        }

        private static void GuardarLog(string message)
        {

        }
    }
}
