using System.ComponentModel.DataAnnotations;
using HumanResources.Web.Enum;

namespace HumanResources.Web.ViewModels;

	public class EmployeeViewModel
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime JoinDate { get; set; }
        public string? DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public string? DesignationName { get; set; }
        public int DesignationId { get; set; }
        
        public IFormFile ProfileImage { get; set; }
        public string? ProfileImagePath { get; set; }
    }


