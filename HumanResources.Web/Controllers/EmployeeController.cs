using HumanResources.Web.Mapper;
using HumanResources.Web.Models;
using HumanResources.Web.ViewModels;
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
    public async Task<IActionResult> HR()
    {
        var employees = await db.Employees.Include(e => e.Department).Include(e => e.Designation).ToListAsync();

        var employeeViewModels = employees.ToViewModel();
        
        return View(employeeViewModels);
    }

    public async Task<IActionResult> Add()
    {
        var departments = await db.Departments.Select(department => new SelectListItem 
        {
            Text = department.Name, 
            Value = department.Id.ToString()
        }).ToListAsync();
        ViewData["departments"] = departments;

        var designations = await db.Designations.Select(designation => new SelectListItem 
        {
            Text = designation.Name, 
            Value = designation.Id.ToString()
        }).ToListAsync();
        ViewData["designations"] = designations;
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(EmployeeViewModel employeeViewModel)
    {
        
        var relativePath = SaveProfileImage(employeeViewModel.ProfileImage);
        
        employeeViewModel.ProfileImagePath = relativePath;
        var employee = employeeViewModel.ToModel();
       
       
        await db.Employees.AddAsync(employee);
        await db.SaveChangesAsync();

        return RedirectToAction(nameof(HR));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var employee = await db.Employees.FindAsync(id);
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Employee employee)
    {
        db.Employees.Update(employee);
        await db.SaveChangesAsync();

        return RedirectToAction(nameof(HR));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var employee = await db.Employees.FindAsync(id);
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Employee employee)
    {
        db.Employees.Remove(employee);
        await db.SaveChangesAsync();

        return RedirectToAction(nameof(HR));
    }

    private string SaveProfileImage(IFormFile profileImage)    

    {   
        var fileName = profileImage.FileName;
        var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
        var relativePath = $"/Images/Profile/{uniqueFileName}";
        var currentAppPath = Directory.GetCurrentDirectory();
        var fullFilePath = Path.Combine(currentAppPath, $"wwwroot/{relativePath}");
        
        var stream = System.IO.File.Create(fullFilePath);
        profileImage.CopyTo(stream);

        return relativePath;
    }

}

