using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Models;
using My_First_Finance_App.Services;

//[Route("[controller]")]
public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
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

		return View(transactions);
	}



	[HttpPost]
	public IActionResult Search(string search)
	{
		var transactions = _transactionService.SearchTransactions(search);
		return View("Index", transactions);
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
