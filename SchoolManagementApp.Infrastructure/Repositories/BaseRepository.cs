using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Infrastructure.Database;
using SchoolManagementApp.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Repositories;

internal abstract class BaseRepository<TEntity, TId>(SchoolDbContext dbContext) : IBaseRepository<TEntity, TId>
    where TEntity : class, IEntity<TId>
{

    protected SchoolDbContext Context { get; } = dbContext;

    public IQueryable<TEntity> GetAll(bool trackChanges)
    {
        var query = Context.Set<TEntity>();

        return trackChanges ? query : query.AsNoTracking();
    }

    public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges)
    {
        var query = Context.Set<TEntity>().Where(expression);

        return trackChanges ? query : query.AsNoTracking();
    }

    public void Create(TEntity entity) => Context.Add(entity);

    public void CreateCollection(IEnumerable<TEntity> entities) => Context.AddRange(entities);

    public void Delete(TEntity entity) => Context.Remove(entity);

    public void Update(TEntity entity) => Context.Update(entity);
}
