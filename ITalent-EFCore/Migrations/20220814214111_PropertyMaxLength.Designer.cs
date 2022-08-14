﻿// <auto-generated />
using System;
using ITalent_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ITalent_EFCore.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20220814214111_PropertyMaxLength")]
    partial class PropertyMaxLength
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DepartmentEmployee", b =>
                {
                    b.Property<int>("departmentsId")
                        .HasColumnType("int");

                    b.Property<int>("employeesId")
                        .HasColumnType("int");

                    b.HasKey("departmentsId", "employeesId");

                    b.HasIndex("employeesId");

                    b.ToTable("DepartmentEmployee");
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TitleId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("City")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Salary", b =>
                {
                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<int>("PrizeAmount")
                        .HasColumnType("int");

                    b.Property<int>("SalaryAmount")
                        .HasColumnType("int");

                    b.HasKey("EmpId");

                    b.ToTable("Salaries");
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Title", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TitleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Titles");
                });

            modelBuilder.Entity("DepartmentEmployee", b =>
                {
                    b.HasOne("ITalent_EFCore.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("departmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITalent_EFCore.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("employeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Employee", b =>
                {
                    b.HasOne("ITalent_EFCore.Models.Location", "Location")
                        .WithMany("employees")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITalent_EFCore.Models.Title", "Title")
                        .WithMany("employees")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Salary", b =>
                {
                    b.HasOne("ITalent_EFCore.Models.Employee", "Employee")
                        .WithOne("Salary")
                        .HasForeignKey("ITalent_EFCore.Models.Salary", "EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Employee", b =>
                {
                    b.Navigation("Salary")
                        .IsRequired();
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Location", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("ITalent_EFCore.Models.Title", b =>
                {
                    b.Navigation("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
