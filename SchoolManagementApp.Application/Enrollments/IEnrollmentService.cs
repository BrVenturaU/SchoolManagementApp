using SchoolManagementApp.Shared.Dtos.Enrollments;
using SchoolManagementApp.Shared;

namespace SchoolManagementApp.Application.Enrollments;

public interface IEnrollmentService {
    Task<Result<IEnumerable<EnrollmentDto>>> GetEnrollments();
    Task<Result<EnrollmentDto>> GetEnrollment(Guid oid);
    Task<Result<EnrollmentToUpdateDto>> GetEnrollmentToUpdate(Guid oid);
    Task<Result> CreateEnrollment(EnrollmentCreationDto EnrollmentCreationDto);
    Task<Result> UpdateEnrollment(Guid oid, EnrollmentToUpdateDto EnrollmentToUpdateDto);
    Task<Result> DeleteEnrollment(Guid oid);
}