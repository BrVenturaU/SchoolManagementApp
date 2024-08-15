using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Students;
using SchoolManagementApp.Infrastructure.Database;
using SchoolManagementApp.Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Infrastructure.Repositories;

internal class StudentRepository(SchoolDbContext dbContext) : BaseRepository<Student, long>(dbContext), IStudentRepository
{
    public void CreateStudent(Student student) => Create(student);

    public void DeleteStudent(Student student) => Delete(student);

    public async Task<Student?> GetStudent(Guid oid, bool trackChanges)
    {
        return await GetByCondition(s => s.Oid == oid, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Student>> GetStudents(bool trackChanges)
    {
        return await GetAll(trackChanges).ToListAsync();
    }
}
