using SchoolManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Domain.Teachers;

public static class TeacherErrors
{
    public static Error NotFound(Guid teacherId) => new("Teachers.NotFound", $"El profesor no existe.");
}