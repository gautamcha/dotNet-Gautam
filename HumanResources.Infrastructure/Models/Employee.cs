
using HumanResources.Web.Enum;

namespace HumanResources.Web.Models;

	public class Employee
	{
		public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime JoinDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Designation Designation { get; set; }
        public int DesignationId { get; set; }
        public string ProfileImagePath { get; set; } 
    }

