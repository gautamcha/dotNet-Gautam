using HumanResources.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Api.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet("hello")]
    public string Hello()
    {
        return "Hello World!";
    }

    [HttpGet("greet")]
    public string[] Greet()
    {
        string[] greets = { "Hi", "Hello", "Good Morning" };
        return greets;
    }

    [HttpGet("departments")]
    public Department[] GetDepartments()
    {
        Department department1 = new Department { Name = "R&D", Established = DateTime.Now };
        Department department2 = new Department { Name = "Operations", Established = DateTime.Now };
        return new Department[] { department1, department2 };
    }
}
