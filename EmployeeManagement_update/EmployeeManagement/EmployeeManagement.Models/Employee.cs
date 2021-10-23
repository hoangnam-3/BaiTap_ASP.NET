using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Key]
        public int ProductId { get; set; }
        public string PhotoPath { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
