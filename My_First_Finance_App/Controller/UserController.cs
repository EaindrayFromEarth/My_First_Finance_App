using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Models;
using My_First_Finance_App.Services;

public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Details(int userId)
    {
        var user = _userService.GetUserById(userId);

        if (user == null)
            return NotFound();

        return View(user);
    }

    // Add other user-related actions as needed
}
