

namespace Sales.Infrastructure.Exeption
{
    public class NegocioException:Exception
    {
        public NegocioException(string menssage):base(menssage)
        {
            GuardarLog(menssage);
        }
        private static void GuardarLog(string menssage) 
        {
           
        }
    }
}
