using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Models;
using My_First_Finance_App.Services;

//[Route("[controller]")]
public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;
    private readonly ISalaryService _salaryService;
    private readonly ICategoryService _categoryService;
    private readonly IUserService _userService;
    public TransactionController(ITransactionService transactionService, ISalaryService salaryService, ICategoryService categoryService, IUserService userService)
    {
        _transactionService = transactionService;
        _salaryService = salaryService;
        _categoryService = categoryService;
        _userService = userService;
    }

    /*	public IActionResult Index(string sortOrder)
		{
			ViewBag.AmountSortOrder = string.IsNullOrEmpty(sortOrder) ? "asc" : sortOrder;

			var transactions = _transactionService.GetAllTransactions();

			// Handle sorting
			transactions = sortOrder switch
			{
				"desc" => transactions.OrderByDescending(t => t.Amount),
				_ => transactions.OrderBy(t => t.Amount),
			};

			return View(transactions);
		}*/

    public IActionResult Index(int page = 1, int pageSize = 10)
    {
        // Adjust pageSize as needed, and you can pass it to the view if necessary
        var transactions = _transactionService.GetAllTransactions(page, pageSize);
        ViewBag.netBalance = _salaryService.AddAllSalary();
        return View(transactions);
    }

    [HttpPost]
    public IActionResult FilterTransactions(int selectedMonth, int selectedYear)
    {
        // Get filtered transactions based on selectedMonth and selectedYear
        var filteredTransactions = _transactionService.FilterTransactions(selectedMonth, selectedYear);

        ViewBag.netBalance = _salaryService.AddAllSalary();

        return View("Index", filteredTransactions);
    }

    [HttpPost]
    public IActionResult Search(string search)
    {
        var transactions = _transactionService.SearchTransactions(search);
        return View("Index", transactions);
    }

    [HttpPost]
    public IActionResult Filter(int selectedMonth, int selectedYear)
    {
        // Add logging to check if the action is being hit
        Console.WriteLine($"Filter Action: Month = {selectedMonth}, Year = {selectedYear}");

        var filteredTransactions = _transactionService.FilterTransactions(selectedMonth, selectedYear);
        return View("Index", filteredTransactions);
    }

    [HttpGet]
    public IActionResult Details(int transactionId)
    {
        var transaction = _transactionService.GetTransactionById(transactionId);

        if (transaction == null)
            return NotFound();

        return View(transaction);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.CategoryList = _categoryService.GetAllCategories();
        ViewBag.Users = _userService.GetAllUsers();
        return View();
    }

    [HttpPost]
    public IActionResult Create(Transaction transaction)
    {
        if (transaction == null)
            return BadRequest();

        _transactionService.AddTransaction(transaction);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    //[Route("Edit/{transactionId}")]
    public IActionResult Edit(int transactionId)
    {
        var transaction = _transactionService.GetTransactionById(transactionId);

        if (transaction == null)
        {
            return NotFound();
        }

        return View(transaction);
    }

    [HttpPost]
    public IActionResult Edit(Transaction transaction)
    {
        if (transaction == null)
        {
            return BadRequest();
        }

        _transactionService.UpdateTransaction(transaction);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int transactionId)
    {
        var transaction = _transactionService.GetTransactionById(transactionId);

        if (transaction == null)
        {
            return NotFound();
        }

        return View(transaction);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int transactionId)
    {
        _transactionService.DeleteTransaction(transactionId);
        return RedirectToAction(nameof(Index));
    }
}
