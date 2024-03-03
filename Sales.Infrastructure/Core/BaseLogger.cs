using Sales.Infrastructure.Interfaces;

namespace Sales.Infrastructure.Core
{
    public class BaseLogger<TEntity> : ILogger<TEntity> where TEntity : class
    {
        private readonly ILogger<TEntity> logger;

        public BaseLogger(ILogger<TEntity> logger)
        {
            this.logger = logger;
        }

        public void LogCritical(string message, Exception ex)
        {
            logger.LogCritical(message, ex);
        }

        public void LogError(string message, Exception ex)
        {
            logger.LogError(message, ex);
        }

        public void LogInformation(string message)
        {
            logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            logger.LogWarning(message);
        }
    }
}
