using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagement.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees3 { get; set; }
    }
}