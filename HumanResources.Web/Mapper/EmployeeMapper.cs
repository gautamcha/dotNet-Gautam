using HumanResources.Web.Models;
using HumanResources.Web.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HumanResources.Web.Mapper;

public static class EmployeeMapper
{
     public static EmployeeViewModel ToViewModel(this Employee employee) =>
        new()
        {
            Id = employee.Id,
            Name = employee.Name,
            Address = employee.Address,
            Gender = employee.Gender,
            Dob = employee.Dob,
            Email = employee.Email,
            JoinDate = employee.JoinDate,
            DesignationId = employee.DepartmentId,
            DesignationName = employee.Designation.Name,
            ProfileImagePath = employee.ProfileImagePath,
            DepartmentId = employee.DepartmentId,
            DepartmentName = employee.Department.Name
        };

        public static List<EmployeeViewModel> ToViewModel(this List<Employee> employees) =>
            employees.Select(employee => employee.ToViewModel()).ToList();

     public static Employee ToModel(this EmployeeViewModel employeeViewModel) =>
        new()
        {
            Id = employeeViewModel.Id,
            Name = employeeViewModel.Name,
            Address = employeeViewModel.Address,
            Gender = employeeViewModel.Gender,
            Dob = employeeViewModel.Dob,
            Email = employeeViewModel.Email,
            JoinDate = employeeViewModel.JoinDate,
            DesignationId = employeeViewModel.DepartmentId,
            ProfileImagePath = employeeViewModel.ProfileImagePath,
            DepartmentId = employeeViewModel.DepartmentId,
            
        };

        public static List<Employee> ToModel(this List<EmployeeViewModel> employeeViewModels) =>
            employeeViewModels.Select(employeeViewModels => employeeViewModels.ToModel()).ToList();



}
   


