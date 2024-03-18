using Microsoft.Extensions.Logging;
using Sales.Infrastructure.Interface;

namespace Sales.Infrastructure.Services
{
    public class LoggerService<T> : ILoggerService
    {
        private readonly ILogger<T> logger;

        public LoggerService(ILogger<T> logger)
        {
            this.logger = logger;
        }
        public void LogCritical(string message)
        {
            logger.LogCritical("Hubo un error:", message);
        }

        public void LogError(string message)
        {
            logger.LogError("Hubo un error:", message);
        }

        public void LogInformation(string message)
        {
            logger.LogInformation("Hubo un error:", message);
        }

        public void LogWarning(string message)
        {
            logger.LogWarning("Hubo un error:", message);
        }
    }
}