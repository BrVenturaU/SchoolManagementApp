using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Students;
using SchoolManagementApp.Shared;
using SchoolManagementApp.Shared.Abstractions;
using SchoolManagementApp.Shared.Dtos.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Application.Students;

internal class StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork) : IStudentService
{
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> CreateStudent(StudentCreationDto studentCreationDto)
    {
        var student = new Student()
        {
            FirstName = studentCreationDto.FirstName,
            MiddleName = studentCreationDto.MiddleName,
            FirstSurname = studentCreationDto.FirstSurname,
            LastSurname = studentCreationDto.LastSurname,
            BirthDate = studentCreationDto.BirthDate,
            Gender = studentCreationDto.Gender,
        };

        _studentRepository.CreateStudent(student);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteStudent(Guid oid)
    {
        var student = await _studentRepository.GetStudent(oid, false);
        if (student is null)
            return StudentErrors.NotFound(oid);

        _studentRepository.DeleteStudent(student);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<StudentDto>> GetStudent(Guid oid)
    {
        var student = await _studentRepository.GetStudent(oid, false);
        if (student is null)
            return StudentErrors.NotFound(oid);

        return new StudentDto(oid, student.FirstName, student.FirstSurname, student.Gender);
    }

    public async Task<Result<IEnumerable<StudentDto>>> GetStudents()
    {
        var students = await _studentRepository.GetStudents(false);

        return students.Select(s => new StudentDto(s.Oid, s.FirstName, s.FirstSurname, s.Gender)).ToList();

    }

    public async Task<Result<StudentToUpdateDto>> GetStudentToUpdate(Guid oid)
    {
        var student = await _studentRepository.GetStudent(oid, false);
        if (student is null)
            return StudentErrors.NotFound(oid);

        return new StudentToUpdateDto()
        {
            FirstName = student.FirstName,
            MiddleName = student.MiddleName,
            FirstSurname = student.FirstSurname,
            LastSurname = student.LastSurname,
            Gender = student.Gender,
            BirthDate = student.BirthDate
        };
    }

    public async Task<Result> UpdateStudent(Guid oid, StudentToUpdateDto studentToUpdateDto)
    {
        var student = await _studentRepository.GetStudent(oid, true);
        if (student is null)
            return StudentErrors.NotFound(oid);

        student.FirstName = studentToUpdateDto.FirstName;
        student.MiddleName = studentToUpdateDto.MiddleName;
        student.FirstSurname = studentToUpdateDto.FirstSurname;
        student.LastSurname = studentToUpdateDto.LastSurname;
        student.Gender = studentToUpdateDto.Gender;
        student.BirthDate = studentToUpdateDto.BirthDate;

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
