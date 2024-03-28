using Sales.Application.Models.Category;

namespace Sales.Web.Models.Category
{
    public class CategoryDetailView
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public CategoryGetModel data { get; set; }
    }
}
