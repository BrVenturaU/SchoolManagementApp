using SchoolManagementApp.Shared.Dtos.Grades;
using SchoolManagementApp.Shared.Dtos.Students;
using SchoolManagementApp.Shared.Dtos.Teachers;
using SchoolManagementApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared.Dtos.Enrollments;

public record EnrollmentDto(Guid Oid, short Year, GradeGroup Group, BaseStudentDto Student, BaseTeacherDto Teacher, BaseGradeDto Grade);
