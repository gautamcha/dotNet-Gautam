
using HumanResources.Web.Models;
using Microsoft.EntityFrameworkCore;

public class HRDbContext: DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Designation> Designations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=HumanResources.db");       
    }

}
