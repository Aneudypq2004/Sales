
using Sales.Domain.Core;

namespace Sales.Domain.Entities.Production
{
    public class Category : BaseEntity
    {
        public bool deleted;

        public string? Descripcion { get; set; }
    }
}
