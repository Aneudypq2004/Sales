
using Microsoft.Extensions.Logging;


namespace Sales.Application.Services
{
    public class BaseService
    {
        protected readonly ILogger logger;

        public BaseService(ILogger logger)
        {
            this.logger = logger;
        }

    }
}
