using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using My_First_Finance_App.Repositories;

namespace My_First_Finance_App.Views.Transaction
{
    public class TEditModel : PageModel
    {
        private readonly TransactionRepository _transactionRepository; // Replace with your actual repository

        public TEditModel(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [BindProperty]
        public My_First_Finance_App.Models.Transaction Transaction { get; set; }

        public IActionResult OnGet(int id)
        {
            // Retrieve the transaction with the given id
            Transaction = _transactionRepository.GetTransactionById(id);

            if (Transaction == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Update the transaction in the repository
            _transactionRepository.UpdateTransaction(Transaction);

            return RedirectToPage("Index");
        }
    }

}
