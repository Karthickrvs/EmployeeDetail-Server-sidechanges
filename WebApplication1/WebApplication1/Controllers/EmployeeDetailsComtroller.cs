using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.EmployeeDetailesFunctionalService;
using WebApplication1.FunctionalService;
using WebApplication1.ObjectModel;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly IEmployeeDetailsFunctionalService Employee;

        public EmployeeDetailsController(IEmployeeDetailsFunctionalService Employee)
        {
            Employee = Employee;
        }

        [HttpPost("AddEmployeedetails")]
        public IActionResult AddEmployeeDetails([FromBody] IEnumerable<EmployeeDetailsDO> employeeDetails)
        {
            this.Employee.AddEmployeeDetails(employeeDetails);
            return Ok("Employees added successfully");
        }

        [HttpGet("GetEmployeedetails")]
        public IActionResult GetEmployyeeDetails()
        {
            var result = this.Employee.GetEmployyeeDetails();
            return Ok(result);
        }

        [HttpGet("GetEmployeedetailsbyId/{EmployeeId}")]
        public IActionResult GetEmployyeeDetailsById(int EmployeeId)
        {
            var result = this.Employee.GetEmployyeeDetailsById(EmployeeId);
            return Ok(result);
        }

        [HttpPut("UpdateEmployeedetails")]
        public IActionResult UpdateEmployee([FromBody] EmployeeDetailsDO employeeDetails)
        {
            this.Employee.UpdateEmployee(employeeDetails);
            return Ok("Employee updated successfully");
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            this.Employee.DeleteEmployee(id);
            return Ok("Employee deleted successfully");
        }
    }
}
