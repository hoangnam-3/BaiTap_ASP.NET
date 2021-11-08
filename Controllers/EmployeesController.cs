using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    //123
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                return (await employeeRepository.GetEmployees()).ToList();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmloyee(int id)
        {
            try
            {
                var result = await employeeRepository.GetEmployee(id);
                if (result == null)
                    return NotFound();
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Loi lay du lieu");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)

                    return BadRequest();

                var emp = await employeeRepository.GetEmployeeByEmail(employee.Email);

                if (emp != null)
                {
                    ModelState.AddModelError("email", "Email nay da co trong csdl");
                    return BadRequest(ModelState);
                }
                var createEmployee = await employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmloyee),
                    new { id = createEmployee.EmployeeId }, createEmployee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Loi tao Nhan vien");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                    return BadRequest("Ma so NV khong khop");

                var employeeToUpdate = await employeeRepository.GetEmployee(id);
                if (employee == null)
                    return NotFound($"NV voi id = {id}");
                return await employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await employeeRepository.GetEmployee(id);
                if (employeeToDelete == null)
                    return NotFound($"Khong tim thay NV co Id = {id}");

                return await employeeRepository.DeleteEmployee(id);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search (string name,Gender? gender)
        {
            try
            {
                var result = await employeeRepository.Search(name,gender);
             if(result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
