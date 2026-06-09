using Microsoft.EntityFrameworkCore;
using WebApplication1.ObjectModel;

namespace WebApplication1
{

    public class EmployeeDB : DbContext
    {

        public EmployeeDB(DbContextOptions<EmployeeDB> options): base(options) 
        {
        
        }

        public DbSet<EmployeeDetailsDTO> EmployeeDetails { get; set;  }
    }
}
