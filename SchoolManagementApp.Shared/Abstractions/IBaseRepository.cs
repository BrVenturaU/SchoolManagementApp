using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared.Abstractions;

public interface IBaseRepository<TEntity, TId> where TEntity : class, IEntity<TId>
{
    IQueryable<TEntity> GetAll(bool trackChanges);
    IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
