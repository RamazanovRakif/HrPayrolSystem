using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using PayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollSystem.DAL
{
    public class PayrollDbContext : IdentityDbContext<Worker>
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options) : base(options) { }

        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<FormerWork> FormerWorks { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<WorkerAbsens> WorkerAbsens { get; set; }
        public DbSet<CompanyWorkPlaceAbsence> CompanyWorkPlaceAbsences { get; set; }

        public DbSet<CompanyWorkPlaceBonus> CompanyWorkPlaceBonus { get; set; }

        public DbSet<WorkerBonus> WorkerBonus { get; set; }

        public DbSet<CompanyWorkPlace> CompanyWorkPlaces { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Sale> Sales { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Education>().HasData(
                new Education { EducationId = 1, EducationName = "Bachelor" },
                new Education { EducationId = 2, EducationName = "Master" }
                );

            builder.Entity<Gender>().HasData(
                new Gender { GenderId = 1, GenderName = "Male" },
                new Gender { GenderId = 2, GenderName = "Female" },
                new Gender { GenderId = 3, GenderName = "Multiple" }
                );

            builder.Entity<MaritalStatus>().HasData(
                new MaritalStatus { MaritalStatusId = 1, MaritalStatusName = "Married" },
                new MaritalStatus { MaritalStatusId = 2, MaritalStatusName = "Single" }
                );


            builder.Entity<Company>().HasData(
                new Company { ID = 1, Name = "Sinteks" },
                new Company { ID=2,Name="Nike"},
                new Company { ID=3, Name="Adidas"}
                
                );

            builder.Entity<Department>().HasData(
                new Department { ID = 1, CompanyId = 1, Name = "IT" },
                new Department { ID = 2, CompanyId = 1, Name = "Programmer" }
                );

            builder.Entity<Absence>().HasData(
                new Absence { ID = 1, Name = "Excusable Absens" },
                new Absence { ID = 2, Name = "UnExcusable Absens" }
                );

            builder.Entity<Position>().HasData(
                new Position { ID = 1, DepartmentId = 2, Name = "Junior Programmer", Salary = 900 },
                new Position { ID = 2, DepartmentId = 2, Name = "Middle Programmer", Salary = 1200 },
                new Position { ID = 3, DepartmentId = 2, Name = "Senior Programmer", Salary = 2500 }
                );
        }

        


    }
}
