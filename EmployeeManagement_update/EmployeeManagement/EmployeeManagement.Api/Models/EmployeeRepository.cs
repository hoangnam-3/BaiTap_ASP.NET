using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees3.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await appDbContext.Employees3
                .FirstOrDefaultAsync(e => e.ProductId == employeeId);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees3.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees3
                .FirstOrDefaultAsync(e => e.ProductId == employee.ProductId);

            if (result != null)
            {
                result.Address = employee.Address;
                result.Description = employee.Description;
                result.Price = employee.Price;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var result = await appDbContext.Employees3
                .FirstOrDefaultAsync(e => e.ProductId == employeeId);
            if (result != null)
            {
                appDbContext.Employees3.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        //public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        //{
        //    IQueryable<Employee> query = appDbContext.Employees3;

        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        query = query.Where(e => e.FirstName.Contains(name)
        //                    || e.LastName.Contains(name));
        //    }

        //    if (gender != null)
        //    {
        //        query = query.Where(e => e.Gender == gender);
        //    }

        //    return await query.ToListAsync();
        //}
        
    }
}