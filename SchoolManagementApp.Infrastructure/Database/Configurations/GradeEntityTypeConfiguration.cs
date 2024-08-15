using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementApp.Domain.Grades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Database.Configurations
{
    internal class GradeEntityTypeConfiguration : BaseEntityTypeConfiguration<Grade, byte>
    {
        public override void Configure(EntityTypeBuilder<Grade> builder)
        {
            base.Configure(builder);

            builder.Property(g => g.Id)
                .UseIdentityColumn();

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(g => g.Description)
                .IsRequired(false)
                .HasMaxLength(200);

            builder.Property(g => g.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            builder.HasData([
                new Grade(){
                    Id = 1,
                    Name = "1°",
                    Description = "Primer Grado. Mayormente asisten niños de 7 años.",
                    IsActive = true
                },
                new Grade(){
                    Id = 2,
                    Name = "2°",
                    Description = "Segundo Grado. Mayormente asisten niños de 8 años.",
                    IsActive = true
                },
                new Grade(){
                    Id = 3,
                    Name = "3°",
                    Description = "Tercer Grado. Mayormente asisten niños de 9 años.",
                    IsActive = true
                },
                new Grade(){
                    Id = 4,
                    Name = "4°",
                    Description = "Cuarto Grado. Mayormente asisten niños de 10 años.",
                    IsActive = true
                },
                new Grade(){
                    Id = 5,
                    Name = "5°",
                    Description = "Quinto Grado. Mayormente asisten niños de 11 años.",
                    IsActive = true
                },
                new Grade(){
                    Id = 6,
                    Name = "6°",
                    Description = "Sexto Grado. Mayormente asisten niños de 12 años.",
                    IsActive = true
                },
                new Grade(){
                    Id = 7,
                    Name = "7°",
                    Description = "Séptimo Grado. Mayormente asisten adolescentes de 13 años.",
                    IsActive = true
                },
                new Grade(){
                    Id = 8,
                    Name = "8°",
                    Description = "Octavo Grado. Mayormente asisten adolescentes de 14 años.",
                    IsActive = true
                },
                new Grade(){
                    Id = 9,
                    Name = "9°",
                    Description = "Sexto Grado. Mayormente asisten adolescentes de 15 años.",
                    IsActive = true
                }
            ]);
        }
    }
}
