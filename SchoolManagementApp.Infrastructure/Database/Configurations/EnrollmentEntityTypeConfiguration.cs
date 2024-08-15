using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementApp.Domain.Enrollments;
using SchoolManagementApp.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Database.Configurations
{
    internal class EnrollmentEntityTypeConfiguration : BaseEntityTypeConfiguration<Enrollment, long>
    {
        public override void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Group)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(e => e.Year)
                .IsRequired();

            builder
                .HasIndex(e => new { e.StudentId, e.GradeId })
                .IsUnique();

            builder.HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .IsRequired();
            builder.HasOne(e => e.Teacher)
                .WithMany()
                .HasForeignKey(e => e.TeacherId)
                .IsRequired();
            builder.HasOne(e => e.Grade)
                .WithMany()
                .HasForeignKey(e => e.GradeId)
                .IsRequired();
        }
    }
}
