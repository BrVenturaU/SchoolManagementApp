using SchoolManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Domain.Grades;

public static class GradeErrors
{
    public static Error NotFound(Guid gradeId) => new("Grades.NotFound", $"The grade does not exists.");
    public static readonly Error Inactive = new("Grades.Inactive", $"The grade is inactive.");
}