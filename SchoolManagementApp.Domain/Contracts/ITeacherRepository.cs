using SchoolManagementApp.Domain.Teachers;

namespace SchoolManagementApp.Domain.Contracts;

public interface ITeacherRepository : IBaseRepository<Teacher, short>
{
    Task<IEnumerable<Teacher>> GetTeachers(bool trackChanges);
    Task<Teacher?> GetTeacher(Guid oid, bool trackChanges);
    void CreateTeacher(Teacher student);
    void DeleteTeacher(Teacher student);
}

