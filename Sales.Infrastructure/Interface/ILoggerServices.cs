﻿

namespace Sales.Infrastructure.Interface
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogError(string message);
        void LogCritical(string message);

        void LogWarning(string message);

    }
}