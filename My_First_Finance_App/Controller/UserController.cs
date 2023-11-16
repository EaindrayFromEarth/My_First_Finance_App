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

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User model)
    {
        if (ModelState.IsValid)
        {
            // Perform authentication logic here
            var user = _userService.GetUserByUsername(model.Username);

            if (user != null)
            {
                // Authentication success
                // Redirect to user profile or dashboard
                return RedirectToAction("ProfileDetails", new { userId = user.UserId });
            }
            else
            {
                // Authentication failed
                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }
        }

        // If we reach here, there was an issue with the login
        return View(model);
    }

    [HttpGet]
    public IActionResult ProfileDetails(int userId)
    {
        var user = _userService.GetUserById(userId);

        if (user == null)
            return NotFound();

        return View(user);
    }

    [HttpGet]
    public IActionResult Edit(int userId)
    {
        var user = _userService.GetUserById(userId);

        if (user == null)
            return NotFound();

        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        if (user == null)
            return BadRequest();

        _userService.UpdateUser(user);
        return RedirectToAction(nameof(ProfileDetails), new { userId = user.UserId });
    }

    [HttpGet]
    public IActionResult Delete(int userId)
    {
        var user = _userService.GetUserById(userId);

        if (user == null)
            return NotFound();

        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int userId)
    {
        _userService.DeleteUser(userId);
        return RedirectToAction(nameof(Index)); // Assuming you have an Index action in UserController
    }
}
