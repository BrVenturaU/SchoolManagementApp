using SchoolManagementApp.Shared.Dtos.Teachers;
using SchoolManagementApp.Shared;

namespace SchoolManagementApp.Application.Teachers;

public interface ITeacherService
{
    Task<Result<IEnumerable<TeacherDto>>> GetTeachers();
    Task<Result<TeacherDto>> GetTeacher(Guid oid);
    Task<Result<TeacherToUpdateDto>> GetTeacherToUpdate(Guid oid);
    Task<Result> CreateTeacher(TeacherCreationDto teacherCreationDto);
    Task<Result> UpdateTeacher(Guid oid, TeacherToUpdateDto teacherToUpdateDto);
    Task<Result> DeleteTeacher(Guid oid);
}
