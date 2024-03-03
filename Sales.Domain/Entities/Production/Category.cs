
using Sales.Domain.Core;

namespace Sales.Domain.Entities.Production
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }

        public string? Descripcion { get; set; }
    }
}
