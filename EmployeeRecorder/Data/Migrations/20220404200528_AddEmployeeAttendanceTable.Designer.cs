﻿// <auto-generated />
using System;
using EmployeeRecorder.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EmployeeRecorder.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220404200528_AddEmployeeAttendanceTable")]
    partial class AddEmployeeAttendanceTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EmployeeRecorder.Data.Entities.EmployeeAttendance", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint")
                        .HasColumnName("employee_id");

                    b.Property<DateTime>("EnterDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("enter_date_time");

                    b.Property<DateTime>("LeaveDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("leave_date_time");

                    b.HasKey("Id")
                        .HasName("pk_employee_attendance");

                    b.HasIndex("EmployeeId")
                        .HasDatabaseName("ix_employee_attendance_employee_id");

                    b.ToTable("employee_attendance", (string)null);
                });

            modelBuilder.Entity("EmployeeRecorder.entity.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("age");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("hiring_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("position");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_employee");

                    b.ToTable("employee", (string)null);

                    b.HasCheckConstraint("age", "age > 0 and age < 120", c => c.HasName("ck_employee_age"));
                });

            modelBuilder.Entity("EmployeeRecorder.Data.Entities.EmployeeAttendance", b =>
                {
                    b.HasOne("EmployeeRecorder.entity.Employee", "Employee")
                        .WithMany("EmployeeAttendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_employee_attendance_employee_employee_id");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeeRecorder.entity.Employee", b =>
                {
                    b.Navigation("EmployeeAttendances");
                });
#pragma warning restore 612, 618
        }
    }
}
