using WebApplication1.Controllers;
using WebApplication1.ObjectModel;

namespace WebApplication1.FunctionalService
{
    public interface IEmployeeDetailsFunctionalService
    {

        IEnumerable<EmployeeDetailsDO> GetEmployyeeDetails();

        IEnumerable<EmployeeDetailsDO> GetEmployyeeDetailsById(int id);

        public void AddEmployeeDetails(IEnumerable<EmployeeDetailsDO> employeeDetails);

        void UpdateEmployee(EmployeeDetailsDO employeeDetails);

        public void DeleteEmployee(int id);

    }
}
