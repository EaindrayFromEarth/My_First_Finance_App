using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Models;
using My_First_Finance_App.Services;

public class TransactionController : Controller
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public IActionResult Index()
    {
        var transactions = _transactionService.GetAllTransactions();
        return View(transactions);
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
    public IActionResult Edit(int transactionId)
    {
        var transaction = _transactionService.GetTransactionById(transactionId);

        if (transaction == null)
            return NotFound();

        return View(transaction);
    }

    [HttpPost]
    public IActionResult Edit(Transaction transaction)
    {
        if (transaction == null)
            return BadRequest();

        _transactionService.UpdateTransaction(transaction);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int transactionId)
    {
        var transaction = _transactionService.GetTransactionById(transactionId);

        if (transaction == null)
            return NotFound();

        return View(transaction);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int transactionId)
    {
        _transactionService.DeleteTransaction(transactionId);
        return RedirectToAction(nameof(Index));
    }
}
