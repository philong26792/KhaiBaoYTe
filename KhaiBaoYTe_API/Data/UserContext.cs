using KhaiBaoYTe_API.Models;
using Microsoft.EntityFrameworkCore;

namespace KhaiBaoYTe_API.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<Employee> Employee {get;set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}