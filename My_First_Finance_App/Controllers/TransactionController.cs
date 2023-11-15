using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Services;

namespace My_First_Finance_App.Controllers
{
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

        // Implement other actions for Create, Edit, Details, Delete
    }
}
