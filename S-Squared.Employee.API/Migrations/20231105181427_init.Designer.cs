﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using S_Squared.EmployeeAPI.Infrastructure.Data;

#nullable disable

namespace S_Squared.EmployeeAPI.Migrations
{
    [DbContext(typeof(S_SquaredDBContext))]
    [Migration("20231105181427_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("employee_seq")
                .IncrementsBy(10);

            modelBuilder.HasSequence("role_seq")
                .IncrementsBy(10);

            modelBuilder.Entity("S_Squared.EmployeeAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "employee_seq");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsManager")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("S_Squared.EmployeeAPI.Models.EmployeeRoles", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeRole", (string)null);
                });

            modelBuilder.Entity("S_Squared.EmployeeAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "role_seq");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("S_Squared.EmployeeAPI.Models.EmployeeRoles", b =>
                {
                    b.HasOne("S_Squared.EmployeeAPI.Models.Employee", null)
                        .WithMany("Roles")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("S_Squared.EmployeeAPI.Models.Employee", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
