using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITalent_EFCore.Models
{
    internal class RestaurantContext : DbContext
    {

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-R8KH0JH\SQLEXPRESS;Initial Catalog=EFCore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salary>()
                .HasKey(s => s.EmpId);
            modelBuilder.Entity<Employee>()
                .HasOne<Salary>(p => p.Salary)
                .WithOne(s => s.Employee)
                .HasForeignKey<Salary>(s => s.EmpId);

            modelBuilder.Entity<Employee>()
                    .Property(e => e.Name)
                    .HasMaxLength(100);
            modelBuilder.Entity<Employee>()
                    .Property(e => e.Surname)
                    .HasMaxLength(100);

            modelBuilder.Entity<Department>()
                    .Property(d => d.Name)
                    .HasMaxLength(50);
            modelBuilder.Entity<Department>()
                    .Property(d => d.Description)
                    .HasMaxLength(250);
            modelBuilder.Entity<Title>()
                    .Property(t => t.TitleName)
                    .HasMaxLength(100);


        }


    }
}
