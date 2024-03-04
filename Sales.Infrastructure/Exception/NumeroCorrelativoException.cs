

namespace Sales.Infrastructure.Exeption
{
    internal class NumeroCorrelativoException: Exception
    {
        public NumeroCorrelativoException(string menssage) : base(menssage)
        {
            GuardarLog(menssage);
        }
        private static void GuardarLog(string menssage)
        {

        }
    }
}
