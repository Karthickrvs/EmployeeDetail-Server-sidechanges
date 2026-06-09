using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.ObjectModel
{
    public class EmployeeDetailsDTO
    {
        public Guid EmployeeId { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public Decimal Salary { get; set; }

        public DateTime JoiningDate { get; set; }

    }
}
