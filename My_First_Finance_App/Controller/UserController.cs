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
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            // You might want to perform additional validation here
            _userService.CreateUser(user);

            return Redirect("/"); // Assuming you have an Index action in UserController
        }

        // If we reach here, there was an issue with the user creation
        return View(user);
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
