using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.Application.Dtos.Product;
using Sales.Web.Models.Product;
using System.Text;

namespace Sales.Web.Controllers
{
    public class ProductController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        public ProductController()
        {
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            var product = new ProductListResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:5235/api/Product/GetProducts"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<ProductListResult>(apiResponse);

                        if (!product!.success)
                        {
                            ViewBag.Message = product.message;
                            return View();
                        }
                    }
                }
            }

            return View(product.data);
        }

        // GET: Details
        public async Task<IActionResult> Details(int id)
        {
            var product = new ProductDetailView();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5235/api/Product/GetProductById?id={id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<ProductDetailView>(apiResponse);

                        if (!product!.success)
                        {
                            ViewBag.Message = product.message;
                            return View();
                        }
                    }
                }
            }

            return View(product.data);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductAddDto productAddDto)
        {
            try
            {
                var product = new ProductDetailView();
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(productAddDto), Encoding.UTF8, "application/json");

                    productAddDto.UserId = 1;
                    productAddDto.ChangeDate = DateTime.Now;

                    using (var response = await httpClient.PostAsync("http://localhost:5235/api/Product/SaveProduct", content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            product = JsonConvert.DeserializeObject<ProductDetailView>(apiResponse);

                            if (!product!.success)
                            {
                                ViewBag.Message = product.message;
                                return View();
                            }
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var product = new ProductDetailView();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5235/api/Product/GetProductById?id={id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<ProductDetailView>(apiResponse);

                        if (!product!.success)
                        {
                            ViewBag.Message = product.message;
                            return View();
                        }
                    }
                }
            }
            return View(product.data);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductUpdateDto productUpdateDto)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var product = new ProductDetailView();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(productUpdateDto), Encoding.UTF8, "application/json");

                    productUpdateDto.UserId = 1;
                    productUpdateDto.ChangeDate = DateTime.Now;

                    using (var response = await httpClient.PostAsync("http://localhost:5235/api/Product/UpdateProduct", content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            product = JsonConvert.DeserializeObject<ProductDetailView>(apiResponse);

                            if (!product!.success)
                            {
                                ViewBag.Message = product.message;
                                return View();
                            }
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
