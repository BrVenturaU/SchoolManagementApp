using SchoolManagementApp.Application.Grades;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Grades;
using SchoolManagementApp.Shared.Abstractions;
using SchoolManagementApp.Shared.Dtos.Grades;
using SchoolManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Application.Grades;

internal class GradeService(IGradeRepository gradeRepository, IUnitOfWork unitOfWork) : IGradeService
{
    private readonly IGradeRepository _gradeRepository = gradeRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> CreateGrade(GradeCreationDto gradeCreationDto)
    {
        var grade = new Grade()
        {
            Name = gradeCreationDto.Name,
            Description = gradeCreationDto.Description,
            IsActive = true
        };

        _gradeRepository.CreateGrade(grade);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteGrade(Guid oid)
    {
        var grade = await _gradeRepository.GetGrade(oid, false);
        if (grade is null)
            return GradeErrors.NotFound(oid);

        _gradeRepository.DeleteGrade(grade);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<GradeDto>> GetGrade(Guid oid)
    {
        var grade = await _gradeRepository.GetGrade(oid, false);
        if (grade is null)
            return GradeErrors.NotFound(oid);

        return new GradeDto(oid, grade.Name, grade.Description, grade.IsActive);
    }

    public async Task<Result<IEnumerable<GradeDto>>> GetGrades()
    {
        var grades = await _gradeRepository.GetGrades(false);

        return grades.Select(g => new GradeDto(g.Oid, g.Name, g.Description, g.IsActive)).ToList();

    }

    public async Task<Result<IEnumerable<GradeDto>>> GetOpenGrades()
    {
        var grades = await _gradeRepository.GetOpenGrades();

        return grades.Select(g => new GradeDto(g.Oid, g.Name, g.Description, g.IsActive)).ToList();

    }

    public async Task<Result<GradeToUpdateDto>> GetGradeToUpdate(Guid oid)
    {
        var grade = await _gradeRepository.GetGrade(oid, false);
        if (grade is null)
            return GradeErrors.NotFound(oid);

        return new GradeToUpdateDto()
        {
            Name = grade.Name,
            Description = grade.Description,
            IsActive = grade.IsActive
        };
    }

    public async Task<Result> UpdateGrade(Guid oid, GradeToUpdateDto gradeToUpdateDto)
    {
        var grade = await _gradeRepository.GetGrade(oid, true);
        if (grade is null)
            return GradeErrors.NotFound(oid);
        
        grade.Name = gradeToUpdateDto.Name;
        grade.Description = gradeToUpdateDto.Description;
        grade.IsActive = gradeToUpdateDto.IsActive;

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}