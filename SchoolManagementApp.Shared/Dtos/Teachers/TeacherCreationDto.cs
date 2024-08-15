using SchoolManagementApp.Shared.Enums;
using SchoolManagementApp.Shared.Validations;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Shared.Dtos.Teachers;

public record TeacherCreationDto
{
    [Required(ErrorMessage = "El primer nombre es requerido.")]
    [MaxLength(50, ErrorMessage = "El máximo de caracteres es de 50.")]
    [NoDigitText(ErrorMessage = "El primer nombre no puede contener números.")]
    public string FirstName { get; init; }
    [MaxLength(50, ErrorMessage = "El máximo de caracteres es de 50.")]
    [NoDigitText(ErrorMessage = "El segundo nombre no puede contener números.")]
    public string? MiddleName { get; init; }
    [Required(ErrorMessage = "El primer apellido es requerido.")]
    [MaxLength(50, ErrorMessage = "El máximo de caracteres es de 50.")]
    [NoDigitText(ErrorMessage = "El primer apellido no puede contener números.")]
    public string FirstSurname { get; init; }
    [MaxLength(50, ErrorMessage = "El máximo de caracteres es de 50.")]
    [NoDigitText(ErrorMessage = "El segundo apellido no puede contener números.")]
    public string? LastSurname { get; init; }
    [Required(ErrorMessage = "El genero es requerido.")]
    public Gender Gender { get; init; }
    [Required(ErrorMessage = "La fecha de nacimiento es requerida.")]
    public DateTime BirthDate { get; init; }
}
