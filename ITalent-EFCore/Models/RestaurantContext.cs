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

        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Location> Locations { get; set; }
        DbSet<Salary> Salaries { get; set; }
        DbSet<Title> Titles { get; set; }

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




        }


    }
}
