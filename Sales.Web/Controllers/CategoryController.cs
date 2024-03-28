using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Sales.Application.Contract;
using Sales.Application.Dtos.Category;
using Sales.Web.Models.Category;
using System.Text;


namespace Sales.Web.Controllers
{
    public class CategoryController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var category = new CategoryListResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("http://localhost:5235/api/Category/GetCategories"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryListResult>(apiResponse);

                        if (!category!.success)
                        {
                            ViewBag.Message = category.message;
                            return View();
                        }
                    }
                }
            }

            return View(category.data);
        }

        // Details
        public async Task<IActionResult> Details(int id)
        {
            var category = new CategoryDetailView();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5235/api/Category/GetCategoryById?id={id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryDetailView>(apiResponse);

                        if (!category!.success)
                        {
                            ViewBag.Message = category.message;
                            return View();
                        }
                    }
                }
            }

            return View(category.data);
        }

        // Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryAddDto categoryAddDto)
        {
            try
            {
                var category = new CategoryDetailView();
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoryAddDto), Encoding.UTF8, "application/json");

                    categoryAddDto.UserId = 1;
                    categoryAddDto.ChangeDate = DateTime.Now;

                    using (var response = await httpClient.PostAsync("http://localhost:5235/api/Category/SaveCategory", content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            category = JsonConvert.DeserializeObject<CategoryDetailView>(apiResponse);

                            if (!category!.success)
                            {
                                ViewBag.Message = category.message;
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

        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var category = new CategoryDetailView();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5235/api/Category/GetCategoryById?id={id}"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        category = JsonConvert.DeserializeObject<CategoryDetailView>(apiResponse);

                        if (!category!.success)
                        {
                            ViewBag.Message = category.message;
                            return View();
                        }
                    }
                }
            }
            return View(category.data);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var category = new CategoryDetailView();

                    StringContent content = new StringContent(JsonConvert.SerializeObject(categoryUpdateDto), Encoding.UTF8, "application/json");

                    categoryUpdateDto.UserId = 1;
                    categoryUpdateDto.ChangeDate = DateTime.Now;

                    using (var response = await httpClient.PostAsync("http://localhost:5235/api/Category/UpdateCategory", content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            category = JsonConvert.DeserializeObject<CategoryDetailView>(apiResponse);

                            if (!category!.success)
                            {
                                ViewBag.Message = category.message;
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
