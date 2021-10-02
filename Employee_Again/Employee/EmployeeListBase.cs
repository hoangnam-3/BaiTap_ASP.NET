using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Models;

namespace Employee
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee2> employees { get; set; }// Trung ten Employee, can doi ten class Employee

        protected override Task OnInitializedAsync()
        {
            loadEmployees();
            return base.OnInitializedAsync();
        }

        private void loadEmployees()
        {
            Employee2 e1 = new Employee2
            {
                employeeId = 1,
                department = new Department { departmentId = 1, departmentName = "Computer Scientist" },
                firstName = "Katagaki",
                lastName = "Naomi",
                email = "katagaki@gmail.com",
                gender = Gender.male,
                dateOfBirth=new DateTime(2001,3,4),
                photoPath="Images/katagaki.png"
            };

            Employee2 e2 = new Employee2
            {
                employeeId = 2,
                department = new Department { departmentId = 2, departmentName = "Computer Scientist" },
                firstName = "Ichigyou",
                lastName = "Ruri",
                email = "ichigyou@gmail.com",
                gender = Gender.female,
                dateOfBirth = new DateTime(2001, 4, 4),
                photoPath = "Images/ichigyou.jpg"
            };

            Employee2 e3 = new Employee2
            {
                employeeId = 3,
                department = new Department { departmentId = 3, departmentName = "Student" },
                firstName = "Ran",
                lastName = "Mori",
                email = "ran@gmail.com",
                gender = Gender.female,
                dateOfBirth = new DateTime(2001, 5, 4),
                photoPath = "Images/ran.png"
            };

            Employee2 e4 = new Employee2
            {
                employeeId = 4,
                department = new Department { departmentId = 4, departmentName = "Detective" },
                firstName = "Shinichi",
                lastName = "Kudo",
                email = "shinichi@gmail.com",
                gender = Gender.male,
                dateOfBirth = new DateTime(2001, 7, 4),
                photoPath = "Images/shinichi.jpg"
            };

            employees = new List<Employee2> { e1, e2, e3, e4 };
        }

    }
}
