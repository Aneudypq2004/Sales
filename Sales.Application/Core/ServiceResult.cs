namespace Sales.Application.Core
{
    public class ServiceResult<TData>
    {
        public ServiceResult()
        {
            this.Success = true;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public TData? Data { get; set; }
    }
}
