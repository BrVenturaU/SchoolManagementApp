﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolManagementApp.Infrastructure.Database;

#nullable disable

namespace SchoolManagementApp.Infrastructure.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20240815004359_Change_Year_ColumnType_From_Tinyint_To_Smallint")]
    partial class Change_Year_ColumnType_From_Tinyint_To_Smallint
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolManagementApp.Domain.Enrollments.Enrollment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte>("GradeId")
                        .HasColumnType("tinyint");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<long>("StudentId")
                        .HasColumnType("bigint");

                    b.Property<short>("TeacherId")
                        .HasColumnType("smallint");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.HasIndex("Oid")
                        .IsUnique();

                    b.HasIndex("TeacherId");

                    b.HasIndex("StudentId", "GradeId")
                        .IsUnique();

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("SchoolManagementApp.Domain.Grades.Grade", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("Oid")
                        .IsUnique();

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Description = "Primer Grado. Mayormente asisten niños de 7 años.",
                            IsActive = true,
                            Name = "1°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = (byte)2,
                            Description = "Segundo Grado. Mayormente asisten niños de 8 años.",
                            IsActive = true,
                            Name = "2°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = (byte)3,
                            Description = "Tercer Grado. Mayormente asisten niños de 9 años.",
                            IsActive = true,
                            Name = "3°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = (byte)4,
                            Description = "Cuarto Grado. Mayormente asisten niños de 10 años.",
                            IsActive = true,
                            Name = "4°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = (byte)5,
                            Description = "Quinto Grado. Mayormente asisten niños de 11 años.",
                            IsActive = true,
                            Name = "5°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = (byte)6,
                            Description = "Sexto Grado. Mayormente asisten niños de 12 años.",
                            IsActive = true,
                            Name = "6°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = (byte)7,
                            Description = "Séptimo Grado. Mayormente asisten adolescentes de 13 años.",
                            IsActive = true,
                            Name = "7°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = (byte)8,
                            Description = "Octavo Grado. Mayormente asisten adolescentes de 14 años.",
                            IsActive = true,
                            Name = "8°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = (byte)9,
                            Description = "Sexto Grado. Mayormente asisten adolescentes de 15 años.",
                            IsActive = true,
                            Name = "9°",
                            Oid = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("SchoolManagementApp.Domain.Students.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastSurname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("Oid")
                        .IsUnique();

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolManagementApp.Domain.Teachers.Teacher", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastSurname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("Oid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.HasKey("Id");

                    b.HasIndex("Oid")
                        .IsUnique();

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("SchoolManagementApp.Domain.Enrollments.Enrollment", b =>
                {
                    b.HasOne("SchoolManagementApp.Domain.Grades.Grade", "Grade")
                        .WithMany()
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementApp.Domain.Students.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolManagementApp.Domain.Teachers.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grade");

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
