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
    [Route("api/[controller]")]
    [ApiController] 
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;
        public DepartmentsController(IDepartmentRepository employeeRepository)
        {
            this.departmentRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            try
            {
                return (await departmentRepository.GetDepartments()).ToList();

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from database");
            }

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                var result = await departmentRepository.GetDepartment(id);
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
        /*[HttpPost]
        public async Task<ActionResult<Department>> CreateDepartment(Department department)
        {
            try
            {
                if (department == null)

                    return BadRequest();

               
                var createDepartment = await departmentRepository.AddDepartment(department);

                return CreatedAtAction(nameof(GetDepartment),
                    new { id = createDepartment.DepartmentId }, CreateDepartment);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Loi tao Department");
            }
        }*/
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Department>> UpdateEmployee(int id, Department department)
        {
            try
            {
                if (id != department.DepartmentId)
                    return BadRequest("Ma so NV khong khop");

                var departmentToUpdate = await departmentRepository.GetDepartment(id);
                if (departmentToUpdate == null)
                    return NotFound($"NV voi id = {id}");
                return await departmentRepository.UpdateDepartment(department);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Department>> DeleteEmployee(int id)
        {
            try
            {
                var departmentToDelete = await departmentRepository.GetDepartment(id);
                if (departmentToDelete == null)
                    return NotFound($"Khong tim thay NV co Id = {id}");

                return await departmentRepository.DeleteDepartment(id);

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(string name)
        {
            try
            {
                var result = await departmentRepository.Search(name);
                if (result.Any())
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
