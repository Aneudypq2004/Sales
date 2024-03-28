using Sales.Application.Models.Product;

namespace Sales.Web.Models.Product
{
    public class ProductDetailView
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public ProductGetModel? data { get; set; }
    }
}
