using Microsoft.EntityFrameworkCore;
namespace EmployeesApp.Models
{
    public class HRDatabaseContext : DbContext
    {
      
        public DbSet<Department> Departments { get; set; } 

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=MOAAZ-PC\SQL2022; Initial Catalog=EmployeesDB; integrated security=SSPI; trusted_connection=true; encrypt=false");
        }
    }
}
