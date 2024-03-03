namespace Sales.Infrastructure.Interfaces
{
    public interface ILogger<TEntity> where TEntity : class
    {
        void LogInformation(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
        void LogCritical(string message, Exception ex);
    }
}
