using SchoolManagementApp.Infrastructure.Database;
using SchoolManagementApp.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Repositories;

// We are relying on DI to manage each repository lifecycle.
// and here just calling save changes from db context.
internal class UnitOfWork(SchoolDbContext dbContext) : IUnitOfWork
{
    private readonly SchoolDbContext _dbContext = dbContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
