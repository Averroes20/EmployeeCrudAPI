using EmployeeCrudAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudAPI.Data
{
    //File ini digunakan untuk konfigurasi kedalam database dan table,
    //namun karena disini menggunakan in-memory maka tidak perlu mengklasifikasikan database nya
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);
            });
        }
    }
}
