using Sales.Domain.Core;
namespace Sales.Domain.Entities.ModuloVentas
{
    public class DetalleVenta : BaseEntity
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set;}

        public string? MarcaProducto { get; set;}

        public string? DescripcionProducto { get; set;}

        public string? CategoriaProducto { get; set; }
        
        public int? Cantidad { get; set;}

        public decimal? Precio { get; set;}


    }
}
