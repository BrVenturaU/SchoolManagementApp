using SchoolManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Domain.Enrollments;

public static class EnrollmentErrors
{
    public static Error NotFound(Guid enrollmentId) => new("Enrollments.NotFound", $"La inscripción no existe.");
    public static Error StudentAlreadyEnrolledToGrade(string studentName, string gradeName) =>
        new("Enrollments.StudentAlreadyEnrolled", $"El estudiante {studentName} ya ha sido inscrito al {gradeName} grado.");
}