using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SchoolManagementApp.Shared.Enums;
using SchoolManagementApp.Shared.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared.Dtos.Students;

public record StudentCreationDto
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

