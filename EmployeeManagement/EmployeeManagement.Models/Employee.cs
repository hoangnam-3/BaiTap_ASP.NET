using System;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int employeeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public Gender gender { get; set; }
        public Department department { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string photoPath { get; set; }
    }
}
