using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Shared.Validations;

public class NoDigitTextAttribute : ValidationAttribute, IClientModelValidator
{
    public NoDigitTextAttribute()
    {
        ErrorMessage = "El campo no puede contener números.";
    }
    public void AddValidation(ClientModelValidationContext context)
    {
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        MergeAttribute(context.Attributes, "data-val", "true");
        MergeAttribute(context.Attributes, "data-val-nodigittext", ErrorMessage);
    }

    private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
    {
        if (attributes.ContainsKey(key))
        {
            return false;
        }
        attributes.Add(key, value);
        return true;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null)
            return ValidationResult.Success;

        var text = value.ToString();

        if (text.Any(char.IsDigit))
            return new ValidationResult(ErrorMessage);

        return ValidationResult.Success;
    }
}
