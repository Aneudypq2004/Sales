
namespace Sales.Api.Models
{
    public class DetalleVentaGetModel
    {
        public int Id { get; set; }
        public string? MarcaProducto { get; set; }

        public string? DescripcionProducto { get; set; }

        public string? CategoriaProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Precio { get; set; }
        public decimal? Total { get; set; }
    }
}
