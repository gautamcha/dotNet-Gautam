using HumanResources.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace HumanResources.Web.Controllers;

public class EmployeeController : Controller
{
    private readonly HRDbContext db;

    public EmployeeController(HRDbContext _db)
    {
        db = _db;
    }
    public IActionResult HR()
    {
        var employees = db.Employees.Include(e => e.Department).Include(e => e.Designation).ToList();

        return View(employees);
    }

    public IActionResult Add()
    {
        var departments = db.Departments.Select(department => new SelectListItem 
        {
            Text = department.Name, 
            Value = department.Id.ToString()
        });
        ViewData["departments"] = departments;

        var designations = db.Designations.Select(designation => new SelectListItem 
        {
            Text = designation.Name, 
            Value = designation.Id.ToString()
        });
        ViewData["designations"] = designations;
        
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(Employee employee)
    {
        var relativePath = SaveProfileImage(employee.ProfileImage);
        employee.ProfileImagePath = relativePath;
        db.Employees.Add(employee);
        db.SaveChanges();

        return RedirectToAction(nameof(HR));
    }

    public IActionResult Edit(int id)
    {
        var employee = db.Employees.Find(id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Edit(Employee employee)
    {
        db.Employees.Update(employee);
        db.SaveChanges();

        return RedirectToAction(nameof(HR));
    }

    public IActionResult Delete(int id)
    {
        var employee = db.Employees.Find(id);
        return View(employee);
    }

    [HttpPost]
    public IActionResult Delete(Employee employee)
    {
        db.Employees.Remove(employee);
        db.SaveChanges();

        return RedirectToAction(nameof(HR));
    }

    private string SaveProfileImage(IFormFile profileImage)    

    {   
        var filename = profileImage.FileName;
        var uniqueFileName = $"{Guid.NewGuid()}_(fileName)";
        var relativePath = $"/images/profile/{uniqueFileName}";
        var currentAppPath = Directory.GetCurrentDirectory();
        var fullFilePath = Path.Combine(currentAppPath, $"wwwroot/(relativePath)");
        
        var stream = System.IO.File.Create(fullFilePath);
        profileImage.CopyTo(stream);

        return relativePath;
    }

}

