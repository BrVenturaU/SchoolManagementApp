using SchoolManagementApp.Domain.Enrollments;

namespace SchoolManagementApp.Domain.Contracts;

public interface IEnrollmentRepository : IBaseRepository<Enrollment, long>
{
    Task<IEnumerable<Enrollment>> GetEnrollments(bool trackChanges);
    Task<Enrollment?> GetEnrollment(Guid oid, bool trackChanges);
    void CreateEnrollment(Enrollment enrollment);
    void DeleteEnrollment(Enrollment enrollment);

    Task<IEnumerable<Enrollment>> GetEnrollmentsWithNavigations(bool trackChanges);
    Task<Enrollment?> GetEnrollmentWithNavigations(Guid oid, bool trackChanges);
    Task<(Enrollment? enrollment, bool isEnrolled)> TryGetEnrolledStudentToGrade(long studentId, byte gradeId, bool trackChanges);
}