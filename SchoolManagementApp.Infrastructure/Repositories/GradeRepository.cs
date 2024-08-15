using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Grades;
using SchoolManagementApp.Infrastructure.Database;

namespace SchoolManagementApp.Infrastructure.Repositories;

internal class GradeRepository(SchoolDbContext dbContext) : BaseRepository<Grade, byte>(dbContext), IGradeRepository
{
    public void CreateGrade(Grade grade) => Create(grade);

    public void DeleteGrade(Grade grade) => Delete(grade);

    public async Task<Grade?> GetGrade(Guid oid, bool trackChanges)
    {
        return await GetByCondition(s => s.Oid == oid, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Grade>> GetGrades(bool trackChanges)
    {
        return await GetAll(trackChanges).ToListAsync();
    }

    public async Task<IEnumerable<Grade>> GetOpenGrades()
    {
        return await GetByCondition(g => !g.Enrollments.Any(), false).ToListAsync();
    }
}