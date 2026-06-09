using Microsoft.EntityFrameworkCore;
using WebApplication1.ObjectModel;

namespace WebApplication1.EmployeeDetailsRepository
{
    public interface IEmployeeDetailsRepo
    {
        public IEnumerable<EmployeeDetailsDTO> GetAllAddEmployeeDetails();

        public EmployeeDetailsDTO GetAllAddEmployeeDetailsbyId(int id);

        public void AddEmployeeDetails(IEnumerable<EmployeeDetailsDTO> employeeDetailsDTO);

        public void UpdateEmployee(IEnumerable<EmployeeDetailsDTO> employeeDetailsDTO);

        public void DeleteEmployee(int id);
    }
}
