namespace Sales.Application.Core
{
    public class ServicesResult<TData>
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public TData? Data { get; set; }
    }
}
