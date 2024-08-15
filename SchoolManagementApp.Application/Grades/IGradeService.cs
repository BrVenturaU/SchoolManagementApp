using SchoolManagementApp.Shared.Dtos.Grades;
using SchoolManagementApp.Shared;

namespace SchoolManagementApp.Application.Grades;

public interface IGradeService
{
    Task<Result<IEnumerable<GradeDto>>> GetGrades();
    Task<Result<IEnumerable<GradeDto>>> GetOpenGrades();
    Task<Result<GradeDto>> GetGrade(Guid oid);
    Task<Result<GradeToUpdateDto>> GetGradeToUpdate(Guid oid);
    Task<Result> CreateGrade(GradeCreationDto gradeCreationDto);
    Task<Result> UpdateGrade(Guid oid, GradeToUpdateDto gradeToUpdateDto);
    Task<Result> DeleteGrade(Guid oid);
}