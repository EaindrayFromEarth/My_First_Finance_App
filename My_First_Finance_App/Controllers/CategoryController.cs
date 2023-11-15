using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Services;

namespace My_First_Finance_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View(categories);
        }

        // Implement other actions for Create, Edit, Details, Delete
    }
}
