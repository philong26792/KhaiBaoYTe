using KhaiBaoYTe_API.Models;
using Microsoft.EntityFrameworkCore;

namespace KhaiBaoYTe_API.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        // private object Property(Func<object, object> p)
        // {
        //     throw new NotImplementedException();
        // }
        public DbSet<Tinh> Tinh { get; set;}
        public DbSet<Huyen> Huyen { get; set;}
        public DbSet<Xa> Xa { get; set;}
        public DbSet<ThongTin> ThongTin { get; set;}
        public DbSet<Mqh> Mqh {get;set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}