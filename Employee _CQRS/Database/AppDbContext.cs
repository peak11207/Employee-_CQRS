using Employee__CQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee__CQRS.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // การกำหนดความสัมพันธ์ระหว่าง Order และ OrderItem

            modelBuilder.Entity<Employee>().HasKey(m => m.EmpNo);
            modelBuilder.Entity<Employee>().Property(m => m.FirstName).IsRequired();
            modelBuilder.Entity<Employee>().Property(m => m.LastName).IsRequired();
            modelBuilder.Entity<Employee>().Property(m => m.Designation).IsRequired();
            modelBuilder.Entity<Employee>().Property(m => m.HireDate).IsRequired();
            modelBuilder.Entity<Employee>().Property(m => m.Salary).IsRequired(); // Ensure the type matches the DB
            modelBuilder.Entity<Employee>().Property(m => m.Comm);
            modelBuilder.Entity<Employee>().Property(m => m.DeptNo).IsRequired();
        }

    }
}
