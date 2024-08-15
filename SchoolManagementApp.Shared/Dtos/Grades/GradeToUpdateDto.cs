using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Shared.Dtos.Grades;

public record GradeToUpdateDto
{
    [Required(ErrorMessage = "El primer nombre es requerido.")]
    [MaxLength(30, ErrorMessage = "El máximo de caracteres es de 50.")]
    public string Name { get; init; }
    [MaxLength(200, ErrorMessage = "El máximo de caracteres es de 50.")]
    public string? Description { get; init; }
    [Required(ErrorMessage = "El estado del grado es requerido.")]
    public bool IsActive { get; set; }
}
