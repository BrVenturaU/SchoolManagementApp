using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Shared.Dtos.Grades;

public record GradeCreationDto
{
    [Required(ErrorMessage = "El primer nombre es requerido.")]
    [MaxLength(30, ErrorMessage = "El máximo de caracteres es de 50.")]
    public string Name { get; init; }

    [MaxLength(200, ErrorMessage = "El máximo de caracteres es de 50.")]
    public string? Description { get; init; }
}