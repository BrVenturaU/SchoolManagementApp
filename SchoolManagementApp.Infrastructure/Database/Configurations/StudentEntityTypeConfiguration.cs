using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementApp.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Database.Configurations
{
    internal class StudentEntityTypeConfiguration : BaseEntityTypeConfiguration<Student, long>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.MiddleName)
               .IsRequired(false)
               .HasMaxLength(50);

            builder.Property(s => s.FirstSurname)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(s => s.LastSurname)
                .IsRequired(false)
               .HasMaxLength(50);

            builder.Property(s => s.Gender)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(s => s.BirthDate)
                .IsRequired();

            
        }
    }
}
