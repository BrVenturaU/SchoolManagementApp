using SchoolManagementApp.Application.Enrollments;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Domain.Enrollments;
using SchoolManagementApp.Shared.Abstractions;
using SchoolManagementApp.Shared.Dtos.Enrollments;
using SchoolManagementApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementApp.Domain.Students;
using SchoolManagementApp.Domain.Teachers;
using SchoolManagementApp.Domain.Grades;
using SchoolManagementApp.Shared.Dtos.Students;
using SchoolManagementApp.Shared.Dtos.Teachers;
using SchoolManagementApp.Shared.Dtos.Grades;
using System.Security.Cryptography;

namespace SchoolManagementApp.Application.Enrollments;

internal class EnrollmentService(
    IEnrollmentRepository enrollmentRepository,
    IStudentRepository studentRepository,
    ITeacherRepository teacherRepository,
    IGradeRepository gradeRepository,
    IUnitOfWork unitOfWork
) : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository = enrollmentRepository;
    private readonly IStudentRepository _studentRepository = studentRepository;
    private readonly IGradeRepository _gradeRepository = gradeRepository;
    private readonly ITeacherRepository _teacherRepository = teacherRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> CreateEnrollment(EnrollmentCreationDto enrollmentCreationDto)
    {
        var student = await _studentRepository.GetStudent(enrollmentCreationDto.StudentOid, false);
        if(student is null)
            return StudentErrors.NotFound(enrollmentCreationDto.StudentOid);

        var teacher = await _teacherRepository.GetTeacher(enrollmentCreationDto.TeacherOid, false);
        if (teacher is null)
            return TeacherErrors.NotFound(enrollmentCreationDto.TeacherOid);

        var grade = await _gradeRepository.GetGrade(enrollmentCreationDto.GradeOid, false);
        if (grade is null)
            return GradeErrors.NotFound(enrollmentCreationDto.GradeOid);

        var(_, isEnrolled) = await _enrollmentRepository.TryGetEnrolledStudentToGrade(student.Id, grade.Id, false);

        if (isEnrolled)
            return EnrollmentErrors.StudentAlreadyEnrolledToGrade($"{student.FirstName} {student.FirstSurname}", grade.Name);

        var Enrollment = new Enrollment()
        {
            Group = enrollmentCreationDto.Group,
            Year = enrollmentCreationDto.Year,
            StudentId = student.Id,
            TeacherId = teacher.Id,
            GradeId = grade.Id,
        };

        _enrollmentRepository.CreateEnrollment(Enrollment);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> DeleteEnrollment(Guid oid)
    {
        var Enrollment = await _enrollmentRepository.GetEnrollment(oid, false);
        if (Enrollment is null)
            return EnrollmentErrors.NotFound(oid);

        _enrollmentRepository.DeleteEnrollment(Enrollment);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result<EnrollmentDto>> GetEnrollment(Guid oid)
    {
        var enrollment = await _enrollmentRepository.GetEnrollmentWithNavigations(oid, false);
        if (enrollment is null)
            return EnrollmentErrors.NotFound(oid);

        return new EnrollmentDto(
            oid,
            enrollment.Year,
            enrollment.Group,
            new BaseStudentDto(enrollment.Student.Oid, enrollment.Student.FirstName, enrollment.Student.FirstSurname),
            new BaseTeacherDto(enrollment.Teacher.Oid, enrollment.Teacher.FirstName, enrollment.Teacher.FirstSurname),
            new BaseGradeDto(enrollment.Grade.Oid, enrollment.Grade.Name, enrollment.Grade.Description)
        );
    }

    public async Task<Result<IEnumerable<EnrollmentDto>>> GetEnrollments()
    {
        var enrollments = await _enrollmentRepository.GetEnrollmentsWithNavigations(false);

        return enrollments.Select(e => new EnrollmentDto(
            e.Oid,
            e.Year,
            e.Group,
            new BaseStudentDto(e.Student.Oid, e.Student.FirstName, e.Student.FirstSurname),
            new BaseTeacherDto(e.Teacher.Oid, e.Teacher.FirstName, e.Teacher.FirstSurname),
            new BaseGradeDto(e.Grade.Oid, e.Grade.Name, e.Grade.Description))
        ).ToList();

    }

    public async Task<Result<EnrollmentToUpdateDto>> GetEnrollmentToUpdate(Guid oid)
    {
        var enrollment = await _enrollmentRepository.GetEnrollmentWithNavigations(oid, false);
        if (enrollment is null)
            return EnrollmentErrors.NotFound(oid);

        return new EnrollmentToUpdateDto()
        {
            Group = enrollment.Group,
            Year = enrollment.Year,
            StudentOid = enrollment.Student.Oid,
            TeacherOid = enrollment.Teacher.Oid,
            GradeOid = enrollment.Grade.Oid,
        };
    }

    public async Task<Result> UpdateEnrollment(Guid oid, EnrollmentToUpdateDto enrollmentToUpdateDto)
    {
        var student = await _studentRepository.GetStudent(enrollmentToUpdateDto.StudentOid, false);
        if (student is null)
            return StudentErrors.NotFound(enrollmentToUpdateDto.StudentOid);

        var teacher = await _teacherRepository.GetTeacher(enrollmentToUpdateDto.TeacherOid, false);
        if (teacher is null)
            return TeacherErrors.NotFound(enrollmentToUpdateDto.TeacherOid);

        var grade = await _gradeRepository.GetGrade(enrollmentToUpdateDto.GradeOid, false);
        if (grade is null)
            return GradeErrors.NotFound(enrollmentToUpdateDto.GradeOid);

        var enrollment = await _enrollmentRepository.GetEnrollment(oid, true);
        if (enrollment is null)
            return EnrollmentErrors.NotFound(oid);

        var (studentGradeEnrollment, isEnrolled) = await _enrollmentRepository.TryGetEnrolledStudentToGrade(student.Id, grade.Id, false);
        if (isEnrolled && studentGradeEnrollment?.Oid != enrollment?.Oid)
            return EnrollmentErrors.StudentAlreadyEnrolledToGrade($"{student.FirstName} {student.FirstSurname}", grade.Name);
        
        enrollment.Group = enrollmentToUpdateDto.Group;
        enrollment.Year = enrollmentToUpdateDto.Year;
        enrollment.StudentId = student.Id;
        enrollment.TeacherId  = teacher.Id;
        enrollment.GradeId = grade.Id;

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
