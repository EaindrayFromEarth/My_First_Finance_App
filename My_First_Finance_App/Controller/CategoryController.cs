using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Models;
using My_First_Finance_App.Services;

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

    [HttpGet]
    public IActionResult Details(int categoryId)
    {
        var category = _categoryService.GetCategoryById(categoryId);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (category == null)
            return BadRequest();

        _categoryService.AddCategory(category);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int categoryId)
    {
        var category = _categoryService.GetCategoryById(categoryId);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (category == null)
            return BadRequest();

        _categoryService.UpdateCategory(category);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int categoryId)
    {
        var category = _categoryService.GetCategoryById(categoryId);

        if (category == null)
            return NotFound();

        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int categoryId)
    {
        _categoryService.DeleteCategory(categoryId);
        return RedirectToAction(nameof(Index));
    }
}

