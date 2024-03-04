using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Infrastructure.Exeption
{
    internal class ConfigurationException:Exception
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
