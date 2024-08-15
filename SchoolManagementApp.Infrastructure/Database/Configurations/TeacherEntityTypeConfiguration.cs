using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementApp.Domain.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Database.Configurations
{
    internal class TeacherEntityTypeConfiguration : BaseEntityTypeConfiguration<Teacher, short>
    {
        public override void Configure(EntityTypeBuilder<Teacher> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(t => t.MiddleName)
                .IsRequired(false)
               .HasMaxLength(50);

            builder.Property(t => t.FirstSurname)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(t => t.LastSurname)
                .IsRequired(false)
               .HasMaxLength(50);

            builder.Property(t => t.Gender)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(t => t.BirthDate)
                .IsRequired();
        }
    }
}
