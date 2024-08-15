using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Teachers;
using SchoolManagementApp.Infrastructure.Database;

namespace SchoolManagementApp.Infrastructure.Repositories;

internal class TeacherRepository(SchoolDbContext dbContext) : BaseRepository<Teacher, short>(dbContext), ITeacherRepository
{
    public void CreateTeacher(Teacher teacher) => Create(teacher);

    public void DeleteTeacher(Teacher teacher) => Delete(teacher);

    public async Task<Teacher?> GetTeacher(Guid oid, bool trackChanges)
    {
        return await GetByCondition(s => s.Oid == oid, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Teacher>> GetTeachers(bool trackChanges)
    {
        return await GetAll(trackChanges).ToListAsync();
    }
}
