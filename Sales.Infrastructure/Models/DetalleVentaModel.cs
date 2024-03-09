
namespace Sales.Domain.Entities.ModuloVentas
{
    public class DetalleVentaModel
    {
        public int Id { get; set; }

        public string? MarcaProducto { get; set;}

        public string? DescripcionProducto { get; set;}

        public string? CategoriaProducto { get; set; }
        
        public int? Cantidad { get; set;}

        public decimal? Precio { get; set;}

        public decimal Total { get; set;}

        
    }
}
