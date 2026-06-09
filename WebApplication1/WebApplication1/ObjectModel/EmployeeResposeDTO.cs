namespace WebApplication1.ObjectModel
{
    public class EmployeeResposeDTO
    {
        public Guid EmployeeId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        public Decimal Salary { get; set; }

        public DateTime JoiningDate { get; set; }
    }
}
