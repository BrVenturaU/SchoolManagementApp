using SchoolManagementApp.Shared;
using SchoolManagementApp.Shared.Dtos.Students;

namespace SchoolManagementApp.Application.Students;

public interface IStudentService
{
    Task<Result<IEnumerable<StudentDto>>> GetStudents();
    Task<Result<StudentDto>> GetStudent(Guid oid);
    Task<Result<StudentToUpdateDto>> GetStudentToUpdate(Guid oid);
    Task<Result> CreateStudent(StudentCreationDto studentCreationDto);
    Task<Result> UpdateStudent(Guid oid, StudentToUpdateDto studentToUpdateDto);
    Task<Result> DeleteStudent(Guid oid);
}
