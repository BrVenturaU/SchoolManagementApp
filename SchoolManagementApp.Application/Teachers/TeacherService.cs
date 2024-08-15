using SchoolManagementApp.Application.Teachers;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Teachers;
using SchoolManagementApp.Shared.Abstractions;
using SchoolManagementApp.Shared.Dtos.Teachers;
using SchoolManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Application.Teachers;

internal class TeacherService(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork) : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository = teacherRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> CreateTeacher(TeacherCreationDto teacherCreationDto)
    {
        var teacher = new Teacher()
        {
            FirstName = teacherCreationDto.FirstName,
            MiddleName = teacherCreationDto.MiddleName,
            FirstSurname = teacherCreationDto.FirstSurname,
            LastSurname = teacherCreationDto.LastSurname,
            BirthDate = teacherCreationDto.BirthDate,
            Gender = teacherCreationDto.Gender,
        };

        _teacherRepository.CreateTeacher(teacher);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteTeacher(Guid oid)
    {
        var teacher = await _teacherRepository.GetTeacher(oid, false);
        if (teacher is null)
            return TeacherErrors.NotFound(oid);

        _teacherRepository.DeleteTeacher(teacher);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<TeacherDto>> GetTeacher(Guid oid)
    {
        var teacher = await _teacherRepository.GetTeacher(oid, false);
        if (teacher is null)
            return TeacherErrors.NotFound(oid);

        return new TeacherDto(oid, teacher.FirstName, teacher.FirstSurname, teacher.Gender);
    }

    public async Task<Result<IEnumerable<TeacherDto>>> GetTeachers()
    {
        var teachers = await _teacherRepository.GetTeachers(false);

        return teachers.Select(t => new TeacherDto(t.Oid, t.FirstName, t.FirstSurname, t.Gender)).ToList();

    }

    public async Task<Result<TeacherToUpdateDto>> GetTeacherToUpdate(Guid oid)
    {
        var teacher = await _teacherRepository.GetTeacher(oid, false);
        if (teacher is null)
            return TeacherErrors.NotFound(oid);

        return new TeacherToUpdateDto()
        {
            FirstName = teacher.FirstName,
            MiddleName = teacher.MiddleName,
            FirstSurname = teacher.FirstSurname,
            LastSurname = teacher.LastSurname,
            Gender = teacher.Gender,
            BirthDate = teacher.BirthDate
        };
    }

    public async Task<Result> UpdateTeacher(Guid oid, TeacherToUpdateDto teacherToUpdateDto)
    {
        var teacher = await _teacherRepository.GetTeacher(oid, true);
        if (teacher is null)
            return TeacherErrors.NotFound(oid);

        teacher.FirstName = teacherToUpdateDto.FirstName;
        teacher.MiddleName = teacherToUpdateDto.MiddleName;
        teacher.FirstSurname = teacherToUpdateDto.FirstSurname;
        teacher.LastSurname = teacherToUpdateDto.LastSurname;
        teacher.Gender = teacherToUpdateDto.Gender;
        teacher.BirthDate = teacherToUpdateDto.BirthDate;

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
