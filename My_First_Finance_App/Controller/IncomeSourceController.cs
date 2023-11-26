using Microsoft.AspNetCore.Mvc;
using My_First_Finance_App.Models;
using My_First_Finance_App.Services;

public class IncomeSourceController : Controller
{
    private readonly IIncomeSourceService _incomeSourceService;

    public IncomeSourceController(IIncomeSourceService incomeSourceService)
    {
        _incomeSourceService = incomeSourceService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var incomeSources = _incomeSourceService.GetAllIncomeSources();
        return View(incomeSources);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(IncomeSource incomeSource)
    {
        if (incomeSource == null)
        {
            return BadRequest();
        }

        _incomeSourceService.AddIncomeSource(incomeSource);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int incomeSourceId)
    {
        var incomeSource = _incomeSourceService.GetIncomeSourceById(incomeSourceId);

        if (incomeSource == null)
        {
            return NotFound();
        }

        return View(incomeSource);
    }

    [HttpPost]
    public IActionResult Edit(IncomeSource incomeSource)
    {
        if (incomeSource == null)
        {
            return BadRequest();
        }

        _incomeSourceService.UpdateIncomeSource(incomeSource);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int incomeSourceId)
    {
        var incomeSource = _incomeSourceService.GetIncomeSourceById(incomeSourceId);

        if (incomeSource == null)
        {
            return NotFound();
        }

        return View(incomeSource);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult ConfirmDelete(int incomeSourceId)
    {
        _incomeSourceService.DeleteIncomeSource(incomeSourceId);
        return RedirectToAction(nameof(Index));
    }
}
