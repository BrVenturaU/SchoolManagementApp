using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Enrollments;
using SchoolManagementApp.Domain.Grades;
using SchoolManagementApp.Infrastructure.Database;

namespace SchoolManagementApp.Infrastructure.Repositories;

internal class EnrollmentRepository(SchoolDbContext dbContext) : BaseRepository<Enrollment, long>(dbContext), IEnrollmentRepository
{
    private readonly SchoolDbContext _dbContext = dbContext;

    public void CreateEnrollment(Enrollment enrollment) => Create(enrollment);

    public void DeleteEnrollment(Enrollment enrollment) => Delete(enrollment);

    public async Task<Enrollment?> GetEnrollment(Guid oid, bool trackChanges)
    {
        return await GetByCondition(e => e.Oid == oid, trackChanges).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Enrollment>> GetEnrollments(bool trackChanges)
    {
        return await GetAll(trackChanges).ToListAsync();
    }

    // This is a problem for Repository Pattern.
    // Should use Query Object Pattern to solve this "non-one entity problem" per repository.
    public async Task<IEnumerable<Enrollment>> GetEnrollmentsWithNavigations(bool trackChanges)
    {
        return await GetAll(trackChanges)
            .Include(e => e.Student)
            .Include(e => e.Teacher)
            .Include(e => e.Grade)
            .ToListAsync();
    }

    public async Task<Enrollment?> GetEnrollmentWithNavigations(Guid oid, bool trackChanges)
    {
        return await GetByCondition(e => e.Oid == oid, trackChanges)
            .Include(e => e.Student)
            .Include(e => e.Teacher)
            .Include(e => e.Grade)
            .FirstOrDefaultAsync();
    }

    public async Task<(Enrollment? enrollment, bool isEnrolled)> TryGetEnrolledStudentToGrade(long studentId, byte gradeId, bool trackChanges)
    {
        var enrollment = await GetByCondition(e => e.StudentId == studentId && e.GradeId == gradeId, trackChanges)
            .FirstOrDefaultAsync();
        return (enrollment, enrollment is not null);
    }


}