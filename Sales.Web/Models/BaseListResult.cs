
namespace Sales.Web.Models
{
    public class BaseListResult<TEntity> where TEntity : class
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public List<TEntity> data { get; set; }
    }
}
