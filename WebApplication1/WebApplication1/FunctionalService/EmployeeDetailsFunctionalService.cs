using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1.EmployeeDetailsRepository;
using WebApplication1.FunctionalService;
using WebApplication1.ObjectModel;

namespace WebApplication1.EmployeeDetailesFunctionalService
{
    public class EmployeeDetailsFunctionalService : IEmployeeDetailsFunctionalService
    {
        private readonly IEmployeeDetailsRepo Empolyeerepo;


        public EmployeeDetailsFunctionalService(IEmployeeDetailsRepo Empolyeerepo)
        {
            Empolyeerepo = Empolyeerepo;
        }

        public void AddEmployeeDetails(IEnumerable<EmployeeDetailsDO> employeeDetails)
        {
            var employees = new List<EmployeeDetailsDTO>();
            foreach (var Employee in employeeDetails) {
                var employee = new EmployeeDetailsDTO
                {
                    Name = Employee.Name,
                    Email = Employee.Email,
                    Department = Employee.Department,
                    Salary = Employee.Salary,
                    JoiningDate = Employee.JoiningDate
                };
                employees.AddRange((IEnumerable<EmployeeDetailsDTO>)Employee);
            }

            this.Empolyeerepo.AddEmployeeDetails(employees);

        }

        public IEnumerable<EmployeeDetailsDO> GetEmployyeeDetails()
        {

           var EmpolyeeDetails  = this.Empolyeerepo.GetAllAddEmployeeDetails();

            var employees = new List<EmployeeDetailsDO>();
            foreach (var Employee in EmpolyeeDetails)
            {
                var employee = new EmployeeDetailsDO
                {
                    Name = Employee.Name,
                    Email = Employee.Email,
                    Department = Employee.Department,
                    Salary = Employee.Salary,
                    JoiningDate = Employee.JoiningDate
                };
                employees.AddRange((IEnumerable<EmployeeDetailsDO>)Employee);
            }

            return employees;
        }

        public IEnumerable<EmployeeDetailsDO> GetEmployyeeDetailsById(int id)
        {
            var employeedetail = this.Empolyeerepo.GetAllAddEmployeeDetailsbyId(id);

            var employee = new EmployeeDetailsDO
            {
                EmployeeId = employeedetail.EmployeeId,
                Name = employeedetail.Name,
                Email = employeedetail.Email,
                Department = employeedetail.Department,
                Salary = employeedetail.Salary,
                JoiningDate = employeedetail.JoiningDate
            };

            return (IEnumerable<EmployeeDetailsDO>)employee;
        }
        public void UpdateEmployee(EmployeeDetailsDO employeeDetails)
        {
            var employee = new EmployeeDetailsDTO
            {
                EmployeeId= employeeDetails.EmployeeId,
                Name = employeeDetails.Name,
                Email = employeeDetails.Email,
                Department = employeeDetails.Department,
                Salary = employeeDetails.Salary,
                JoiningDate = employeeDetails.JoiningDate
            };

            this.Empolyeerepo.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            this.Empolyeerepo.DeleteEmployee(id);
        }
    }
}
