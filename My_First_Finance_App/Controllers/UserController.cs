using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Services;

namespace My_First_Finance_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index(int userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }

            // Add code to retrieve user transactions and categories

            return View(user);
        }

        // Implement other user-related actions
    }
}
