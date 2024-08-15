using SchoolManagementApp.Domain.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Domain.Contracts;

public interface IStudentRepository : IBaseRepository<Student, long>
{
    Task<IEnumerable<Student>> GetStudents(bool trackChanges);
    Task<Student?> GetStudent(Guid oid, bool trackChanges);
    void CreateStudent(Student student);
    void DeleteStudent(Student student);
}

