using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Database.Configurations
{
    internal abstract class BaseEntityTypeConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Oid)
                .IsRequired()
                .HasDefaultValueSql("NEWID()");
            builder.HasIndex(e => e.Oid).IsUnique();
        }
    }
}
