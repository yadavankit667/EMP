using EMS.API.Interface;
using EMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employeeContext;

        public EmployeeController(IEmployee employeeContext)
        {
            this.employeeContext = employeeContext;
        }

        [HttpGet("EmployeeList")]
        public IActionResult EmployeeList()
        {
            return Ok(employeeContext.GetEmployee());
        }

        [HttpPost("SaveEmployee")]
        public IActionResult SaveEmployee(Employee employee)
        {
            return Ok(employeeContext.SaveEmployee(employee));
        }

        [HttpPut("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee, int id)
        {
            return Ok(employeeContext.UpdateEmployee(employee, id));
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            return Ok(employeeContext.DeleteEmployee(id));
        }

        [HttpGet("GetEmployeeById")]
        public IActionResult GetEmployeeById(int id)
        {
            return Ok(employeeContext.GetEmployeeById(id));
        }

        [HttpGet("SearchEmployee")]
        public IActionResult SearchEmployee(string searchText)
        {
            return Ok(employeeContext.SearchEmployee(searchText));
        }
    }
}
