using WebApplication1.ObjectModel;

namespace WebApplication1.EmployeeDetailsRepository
{
    public class EmployeeDetailsRepo : IEmployeeDetailsRepo
    {

        private readonly EmployeeDB context;

        public EmployeeDetailsRepo(EmployeeDB Context)
        {
            context = Context;
        }

        public IEnumerable<EmployeeDetailsDTO> GetAllAddEmployeeDetails()
        {
            var AllEmployeeDetails = context.EmployeeDetails.ToList();

            return  AllEmployeeDetails;
        }

        public EmployeeDetailsDTO GetAllAddEmployeeDetailsbyId(int id)
        {
            var SpecificEmployee = context.EmployeeDetails.Find(id);

            return SpecificEmployee;
        }

        public void AddEmployeeDetails(IEnumerable<EmployeeDetailsDTO> employeeDetailsDTO)
        {
            context.EmployeeDetails.AddRange(employeeDetailsDTO);
            context.SaveChanges();
        }

        public void UpdateEmployee(IEnumerable<EmployeeDetailsDTO> employeeDetailsDTO)
        {
            var ids = employeeDetailsDTO.Select(e => e.EmployeeId).ToList();

            var existingEmployees = context.EmployeeDetails
                .Where(e => ids.Contains(e.EmployeeId))
                .ToList();

            foreach (var employee in existingEmployees)
            {
                var updatedData = employeeDetailsDTO
                    .FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

                if (updatedData != null)
                {
                    employee.Name = updatedData.Name;
                    employee.Email = updatedData.Email;
                    employee.Department = updatedData.Department;
                    employee.Salary = updatedData.Salary;
                    employee.JoiningDate = updatedData.JoiningDate;
                }
            }

            context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
           var existingEmpoyee = context.EmployeeDetails.Find(id);

            if (existingEmpoyee != null)
            {
                context.EmployeeDetails.RemoveRange(existingEmpoyee);
                context.SaveChanges();
            }
        }

    }
}
