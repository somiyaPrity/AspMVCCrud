using AspMVCCrud.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AspMVCCrud.Data
{
    public class MVCDbContext:DbContext
    {
        public MVCDbContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
