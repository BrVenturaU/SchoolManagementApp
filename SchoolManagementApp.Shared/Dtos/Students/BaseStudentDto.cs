namespace SchoolManagementApp.Shared.Dtos.Students;

public record BaseStudentDto(Guid Oid, string FirstName, string FirstSurname)
{
    public string FullName => $"{FirstName} {FirstSurname}";
};
