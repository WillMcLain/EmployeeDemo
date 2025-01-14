﻿// <auto-generated />
using System;
using EmployeeDemo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeDemo.Database.Migrations
{
    [DbContext(typeof(EmployeeDemoDbContext))]
    [Migration("20230418161830_Add Employee seed data")]
    partial class AddEmployeeseeddata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeDemo.Database.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(2023, 4, 18, 11, 18, 30, 12, DateTimeKind.Local).AddTicks(8898),
                            FirstName = "William",
                            LastName = "Shakespeare",
                            MiddleName = "Bob"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(2023, 4, 18, 11, 18, 30, 12, DateTimeKind.Local).AddTicks(8959),
                            FirstName = "John",
                            LastName = "Doe",
                            MiddleName = "Ron"
                        },
                        new
                        {
                            Id = 3,
                            DateOfBirth = new DateTime(2023, 4, 18, 11, 18, 30, 12, DateTimeKind.Local).AddTicks(8963),
                            FirstName = "Larry",
                            LastName = "Bird",
                            MiddleName = "Bill"
                        },
                        new
                        {
                            Id = 4,
                            DateOfBirth = new DateTime(2023, 4, 18, 11, 18, 30, 12, DateTimeKind.Local).AddTicks(8967),
                            FirstName = "Matt",
                            LastName = "Geer",
                            MiddleName = "Linus"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
