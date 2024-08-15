namespace SchoolManagementApp.Shared.Dtos.Teachers;

public record BaseTeacherDto(Guid Oid, string FirstName, string FirstSurname)
{
    public string FullName => $"{FirstName} {FirstSurname}";
};
