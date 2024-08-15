using SchoolManagementApp.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Shared.Dtos.Enrollments;

public record EnrollmentCreationDto
{
    [Required(ErrorMessage = "El grupo al que pertenecera el estudiante en el grado es requerido.")]
    public GradeGroup Group { get; set; }

    [Required(ErrorMessage = "El año de curso para la inscripción es requerido.")]
    public short Year { get; set; }
    [Required(ErrorMessage = "El estudiante a inscribir es requerido.")]
    public Guid StudentOid { get; set; }
    [Required(ErrorMessage = "El profesor que dara el curso es requerido.")]
    public Guid TeacherOid { get; set; }
    [Required(ErrorMessage = "El grado para la inscripción requerido.")]
    public Guid GradeOid { get; set; }
}