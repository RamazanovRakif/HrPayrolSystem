﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayrollSystem.DAL;

namespace PayrollSystem.Migrations
{
    [DbContext(typeof(PayrollDbContext))]
    [Migration("20191017222932_ChangedWorkerModel")]
    partial class ChangedWorkerModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PayrollSystem.Models.Absence", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Absences");

                    b.HasData(
                        new { ID = 1, Name = "Excusable Absens" },
                        new { ID = 2, Name = "UnExcusable Absens" }
                    );
                });

            modelBuilder.Entity("PayrollSystem.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addres")
                        .HasMaxLength(200);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("OpenCompany");

                    b.Property<string>("TelNumber")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Companies");

                    b.HasData(
                        new { ID = 1, Name = "Sinteks", OpenCompany = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ID = 2, Name = "Nike", OpenCompany = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { ID = 3, Name = "Adidas", OpenCompany = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("PayrollSystem.Models.CompanyWorkPlace", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ChangedDate");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("PositionId");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("CompanyWorkPlaces");
                });

            modelBuilder.Entity("PayrollSystem.Models.CompanyWorkPlaceAbsence", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyWorkPlaceId");

                    b.Property<int>("ExcusableAbsens");

                    b.Property<int>("UnExcusableAbsens");

                    b.HasKey("ID");

                    b.HasIndex("CompanyWorkPlaceId");

                    b.ToTable("CompanyWorkPlaceAbsences");
                });

            modelBuilder.Entity("PayrollSystem.Models.CompanyWorkPlaceBonus", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("BonusSalary");

                    b.Property<string>("CompanyWorkPlaceId");

                    b.HasKey("ID");

                    b.HasIndex("CompanyWorkPlaceId");

                    b.ToTable("CompanyWorkPlaceBonus");
                });

            modelBuilder.Entity("PayrollSystem.Models.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("Departments");

                    b.HasData(
                        new { ID = 1, CompanyId = 1, Name = "IT" },
                        new { ID = 2, CompanyId = 1, Name = "Programmer" }
                    );
                });

            modelBuilder.Entity("PayrollSystem.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EducationName")
                        .IsRequired();

                    b.HasKey("EducationId");

                    b.ToTable("Educations");

                    b.HasData(
                        new { EducationId = 1, EducationName = "Bachelor" },
                        new { EducationId = 2, EducationName = "Master" }
                    );
                });

            modelBuilder.Entity("PayrollSystem.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Born");

                    b.Property<string>("DistrictRegistration")
                        .IsRequired();

                    b.Property<int>("EducationId");

                    b.Property<string>("FatherName")
                        .IsRequired();

                    b.Property<int>("GenderId");

                    b.Property<string>("Image");

                    b.Property<int>("MaritalStatusId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTime>("PersonalityCardEndDate");

                    b.Property<string>("PersonalityCardNumber")
                        .IsRequired();

                    b.Property<string>("Residence")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("EducationId");

                    b.HasIndex("GenderId");

                    b.HasIndex("MaritalStatusId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PayrollSystem.Models.FormerWork", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EnterDate");

                    b.Property<DateTime>("LeaveDate");

                    b.Property<string>("LeaveReason");

                    b.Property<string>("WorkName");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeId");

                    b.ToTable("FormerWorks");
                });

            modelBuilder.Entity("PayrollSystem.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GenderName")
                        .IsRequired();

                    b.HasKey("GenderId");

                    b.ToTable("Genders");

                    b.HasData(
                        new { GenderId = 1, GenderName = "Male" },
                        new { GenderId = 2, GenderName = "Female" },
                        new { GenderId = 3, GenderName = "Multiple" }
                    );
                });

            modelBuilder.Entity("PayrollSystem.Models.MaritalStatus", b =>
                {
                    b.Property<int>("MaritalStatusId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MaritalStatusName")
                        .IsRequired();

                    b.HasKey("MaritalStatusId");

                    b.ToTable("MaritalStatuses");

                    b.HasData(
                        new { MaritalStatusId = 1, MaritalStatusName = "Married" },
                        new { MaritalStatusId = 2, MaritalStatusName = "Single" }
                    );
                });

            modelBuilder.Entity("PayrollSystem.Models.Position", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Salary");

                    b.HasKey("ID");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Positions");

                    b.HasData(
                        new { ID = 1, DepartmentId = 2, Name = "Junior Programmer", Salary = 900m },
                        new { ID = 2, DepartmentId = 2, Name = "Middle Programmer", Salary = 1200m },
                        new { ID = 3, DepartmentId = 2, Name = "Senior Programmer", Salary = 2500m }
                    );
                });

            modelBuilder.Entity("PayrollSystem.Models.Salary", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CalculatedDate");

                    b.Property<int>("EmployeeId");

                    b.Property<decimal>("TotalSalary");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("PayrollSystem.Models.Sale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("SaleSalary");

                    b.Property<int>("ShopId");

                    b.HasKey("ID");

                    b.HasIndex("ShopId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("PayrollSystem.Models.Shop", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("PayrollSystem.Models.Vacation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("WorkerId")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("WorkerId");

                    b.ToTable("Vacations");
                });

            modelBuilder.Entity("PayrollSystem.Models.Worker", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Account");

                    b.Property<DateTime>("BeginDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("EmployeeId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PassText");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("PositionId");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("ShopId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<bool>("Worked");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PositionId");

                    b.HasIndex("ShopId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PayrollSystem.Models.WorkerAbsens", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AbsenceId");

                    b.Property<int?>("Count");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Reason")
                        .IsRequired();

                    b.Property<string>("WorkerId")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AbsenceId");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerAbsens");
                });

            modelBuilder.Entity("PayrollSystem.Models.WorkerBonus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BonusDate");

                    b.Property<decimal>("BonusSalary");

                    b.Property<string>("Reason")
                        .IsRequired();

                    b.Property<string>("WorkerId")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("WorkerId");

                    b.ToTable("WorkerBonus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PayrollSystem.Models.Worker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PayrollSystem.Models.Worker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollSystem.Models.Worker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("PayrollSystem.Models.Worker")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.CompanyWorkPlace", b =>
                {
                    b.HasOne("PayrollSystem.Models.Employee", "Employee")
                        .WithMany("CompanyWorkPlaces")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollSystem.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.CompanyWorkPlaceAbsence", b =>
                {
                    b.HasOne("PayrollSystem.Models.CompanyWorkPlace", "CompanyWorkPlace")
                        .WithMany("CompanyWorkPlaceAbsences")
                        .HasForeignKey("CompanyWorkPlaceId");
                });

            modelBuilder.Entity("PayrollSystem.Models.CompanyWorkPlaceBonus", b =>
                {
                    b.HasOne("PayrollSystem.Models.CompanyWorkPlace", "CompanyWorkPlace")
                        .WithMany("CompanyWorkPlaceBonus")
                        .HasForeignKey("CompanyWorkPlaceId");
                });

            modelBuilder.Entity("PayrollSystem.Models.Department", b =>
                {
                    b.HasOne("PayrollSystem.Models.Company", "Company")
                        .WithMany("Departments")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.Employee", b =>
                {
                    b.HasOne("PayrollSystem.Models.Education", "Education")
                        .WithMany("Employees")
                        .HasForeignKey("EducationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollSystem.Models.Gender", "Gender")
                        .WithMany("Employees")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollSystem.Models.MaritalStatus", "MaritalStatus")
                        .WithMany("Employees")
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.FormerWork", b =>
                {
                    b.HasOne("PayrollSystem.Models.Employee", "Employee")
                        .WithMany("FormerWorks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.Position", b =>
                {
                    b.HasOne("PayrollSystem.Models.Department", "Department")
                        .WithMany("Positions")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.Salary", b =>
                {
                    b.HasOne("PayrollSystem.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.Sale", b =>
                {
                    b.HasOne("PayrollSystem.Models.Shop", "Shop")
                        .WithMany("Sales")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.Shop", b =>
                {
                    b.HasOne("PayrollSystem.Models.Company", "Company")
                        .WithMany("Shops")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.Vacation", b =>
                {
                    b.HasOne("PayrollSystem.Models.Worker", "Worker")
                        .WithMany("Vacations")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.Worker", b =>
                {
                    b.HasOne("PayrollSystem.Models.Employee", "Employee")
                        .WithOne("Worker")
                        .HasForeignKey("PayrollSystem.Models.Worker", "EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollSystem.Models.Position", "Position")
                        .WithMany("Workers")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollSystem.Models.Shop", "Shop")
                        .WithMany("Workers")
                        .HasForeignKey("ShopId");
                });

            modelBuilder.Entity("PayrollSystem.Models.WorkerAbsens", b =>
                {
                    b.HasOne("PayrollSystem.Models.Absence", "Absence")
                        .WithMany("WorkerAbsens")
                        .HasForeignKey("AbsenceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PayrollSystem.Models.Worker", "Worker")
                        .WithMany("WorkerAbsens")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PayrollSystem.Models.WorkerBonus", b =>
                {
                    b.HasOne("PayrollSystem.Models.Worker", "Worker")
                        .WithMany("WorkerBonus")
                        .HasForeignKey("WorkerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}