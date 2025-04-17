using ASP.NETCoreMVCAssignment1.QuachVanViet.Enum;
using ASP.NETCoreMVCAssignment1.QuachVanViet.Helpers;
using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using Microsoft.AspNetCore.Mvc;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Models;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;

namespace R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Controllers;

public class RookiesController : Controller
{
    private readonly IPersonService _personService;
    private readonly IPersonFilterService _personFilterService;

    public RookiesController (IPersonService personService, IPersonFilterService personFilterService)
    {
        _personService = personService;
        _personFilterService = personFilterService;
    }

    public IActionResult Index(Filter filter = Filter.All)
    {
        var people = _personFilterService.FilterPeople(filter);
        ViewBag.filter = filter;
        return View(people);
    }
    public IActionResult Create()
    {
        return View("FormPerson", new Person());
    }
    public IActionResult Edit(Guid id)
    {
        var person = _personService.GetPersonById(id);
        if (person == null)
        {
            return NotFound();
        }
        return View("FormPerson",person);
    }
    public IActionResult Details(Guid id)
    {
        var person = _personService.GetPersonById(id);
        if (person == null)
        {
            return NotFound();
        }
        return View("Details", person);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Save(Person person)
    {
        if (!ModelState.IsValid)
        {
            return View("FormPerson", person);
        }
        if (person.Id == Guid.Empty) // Create
        {
            _personService.Create(person);
            return RedirectToAction("Index");
        }
        else // Edit
        {
            _personService.Update(person);
            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Guid id)
    {
        var person = _personService.GetPersonById(id);
        if (person == null)
        {
            return NotFound();
        }
        _personService.Delete(id);
        var deletedName = $"{person.LastName} {person.FirstName}";
        return RedirectToAction("Confirmation", new { name = deletedName });
    }
    public IActionResult Confirmation(string name)
    {
        ViewBag.Message = $"Person {name} was removed from the list successfully!";
        return View();
    }
    public IActionResult ExportToExcel()
    {
        var people = _personService.ListAllPerson();
        var fileBytes = FileExport.ExportToExcel(people);
        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "PeopleList.xlsx");
    }
}