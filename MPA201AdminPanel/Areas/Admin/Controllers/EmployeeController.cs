using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using MPA201AdminPanel.Contexts;

namespace MPA201AdminPanel.Areas.Admin.Controllers;
[Area("Admin")]
public class EmployeeController : Controller
{
    readonly AppDbContext _context;
    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var employees = _context.Employees.ToList();
        ViewBag.Employees = employees;
        return View(employees);
    }

    [HttpGet]
    public IActionResult Create() 
    { 
        return View();
    }


    [HttpPost]
    public IActionResult Create(Employee employee)
    {
        if (!ModelState.IsValid) return View(employee);
        employee.CreatedDate = DateTime.UtcNow.AddHours(4);
        employee.IsDeleted = false;
        _context.Add(employee);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost("employee/{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
        if (employee == null) return NotFound("Employee is not found");
        _context.Remove(employee);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null) return NotFound("Employee is not found");
        return View(employee);
    }
    [HttpPost]
    public IActionResult Update(Employee employee)
    {
        if (!ModelState.IsValid) return View();
        var existEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
        if (existEmployee == null) return NotFound("Error");

        existEmployee.FirstName = employee.FirstName;
        existEmployee.LastName = employee.LastName;
        existEmployee.ImageName = employee.ImageName;
        existEmployee.ImageURL = employee.ImageURL;
        _context.Employees.Update(existEmployee);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}
