using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> employees { get; set; }

        protected override Task OnInitializedAsync()
        {
            loadEmployees();
            return base.OnInitializedAsync();
        }

        private void loadEmployees()
        {
            Employee e1 = new Employee
            {
                employeeId = 1,
                firstName = "Katagaki",
                lastName = "Naomi",
                email = "katagaki@gmail.com",
                gender = Gender.male,
                department = new Department { departmentId = 1, departmentName = "Student" },
                photoPath = "Images/katagaki.png",
                dateOfBirth = new DateTime(2001, 4, 3)
            };

            Employee e2 = new Employee
            {
                employeeId = 1,
                firstName = "Ichigyou",
                lastName = "Ruri",
                email = "ichigyou@gmail.com",
                gender = Gender.female,
                department = new Department { departmentId = 2, departmentName = "Student" },
                photoPath = "Images/ichigyou.jpg",
                dateOfBirth = new DateTime(2001, 5, 5)
            };

            Employee e3 = new Employee
            {
                employeeId = 1,
                firstName = "Shinichi",
                lastName = "Kudo",
                email = "shinichi@gmail.com",
                gender = Gender.male,
                department = new Department { departmentId = 3, departmentName = "Detective" },
                photoPath = "Images/shinichi.jpg",
                dateOfBirth = new DateTime(2001, 6, 23)
            };

            Employee e4 = new Employee
            {
                employeeId = 1,
                firstName = "Ran",
                lastName = "Mori",
                email = "ran@gmail.com",
                gender = Gender.female,
                department = new Department { departmentId = 4, departmentName = "Student" },
                photoPath = "Images/ran.png",
                dateOfBirth = new DateTime(2001, 2, 28)
            };

            employees = new List<Employee> { e1, e2, e3, e4 };
        }
    }
}

