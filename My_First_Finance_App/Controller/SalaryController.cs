using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Models;
using My_First_Finance_App.Services;

public class SalaryController : Controller
{
    private readonly ISalaryService _salaryService;
    private readonly IIncomeSourceService _incomeSourceService; // Inject the IncomeSource service

    public SalaryController(ISalaryService salaryService, IIncomeSourceService incomeSourceService)
    {
        _salaryService = salaryService;
        _incomeSourceService = incomeSourceService;
    }

    public IActionResult Index()
	{
		var salaries = _salaryService.GetAllSalaries();
		return View(salaries);
	}


    [HttpGet]
    public IActionResult Create()
    {
        // Get all Income Sources to populate the dropdown list
        ViewBag.IncomeSources = _incomeSourceService.GetAllIncomeSources();
        return View();
    }

    [HttpPost]
	public IActionResult Create(Salary salary)
	{
		if (salary == null)
			return BadRequest();

		_salaryService.AddSalary(salary);
		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public IActionResult Edit(int salaryId)
	{
		var salary = _salaryService.GetSalaryById(salaryId);

		if (salary == null)
			return NotFound();

		return View(salary);
	}

	[HttpPost]
	public IActionResult Edit(Salary salary)
	{
		if (salary == null)
			return BadRequest();

		_salaryService.UpdateSalary(salary);
		return RedirectToAction(nameof(Index));
	}

	[HttpGet]
	public IActionResult Delete(int salaryId)
	{
		var salary = _salaryService.GetSalaryById(salaryId);

		if (salary == null)
			return NotFound();

		return View(salary);
	}

	[HttpPost, ActionName("Delete")]
	public IActionResult ConfirmDelete(int salaryId)
	{
		_salaryService.DeleteSalary(salaryId);
		return RedirectToAction(nameof(Index));
	}


}
