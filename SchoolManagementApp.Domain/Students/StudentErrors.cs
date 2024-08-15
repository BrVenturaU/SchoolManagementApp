using SchoolManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Domain.Students;

public static class StudentErrors
{
    public static Error NotFound(Guid studentId) => new("Students.NotFound", $"El estudiante no existe.");
}