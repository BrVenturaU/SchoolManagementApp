using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Domain.Enrollments;
using SchoolManagementApp.Domain.Grades;
using SchoolManagementApp.Domain.Students;
using SchoolManagementApp.Domain.Teachers;
using SchoolManagementApp.Infrastructure.Database.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Database;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TeacherEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new GradeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EnrollmentEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}
