
namespace Sales.Infrastructure.Intefaces
{
    public interface ILoggerService
    {   

        void Info(string message);
        void Warning(string message);
        void Error(string message);
        void Critical(string message);

    }
}
