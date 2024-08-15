using SchoolManagementApp.Domain.Grades;

namespace SchoolManagementApp.Domain.Contracts;

public interface IGradeRepository : IBaseRepository<Grade, byte>
{
    Task<IEnumerable<Grade>> GetOpenGrades();
    Task<IEnumerable<Grade>> GetGrades(bool trackChanges);
    Task<Grade?> GetGrade(Guid oid, bool trackChanges);
    void CreateGrade(Grade grade);
    void DeleteGrade(Grade grade);
}

