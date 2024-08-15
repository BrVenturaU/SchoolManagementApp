using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Application.Enrollments;
using SchoolManagementApp.Application.Grades;
using SchoolManagementApp.Application.Students;
using SchoolManagementApp.Application.Teachers;
using SchoolManagementApp.Domain.Contracts;
using SchoolManagementApp.Shared.Dtos.Enrollments;
using SchoolManagementApp.Shared.Dtos.Grades;
using SchoolManagementApp.Shared.Enums;

namespace SchoolManagementApp.Web.Controllers
{
    public class EnrollmentsController(
        IEnrollmentService enrollmentService,
        IStudentService studentService,
        ITeacherService teacherService,
        IGradeService gradeService
    ) : Controller
    {
        private readonly IEnrollmentService _enrollmentService = enrollmentService;
        private readonly IStudentService _studentService = studentService;
        private readonly ITeacherService _teacherService = teacherService;
        private readonly IGradeService _gradeService = gradeService;

        public async Task<IActionResult> Index()
        {
            var result = await _enrollmentService.GetEnrollments();
            return View(result.Value);
        }

        public async Task<IActionResult> Create()
        {
            var year = DateTime.Now.Year;
            var yearsRange = 10;
            ViewBag.Students = (await _studentService.GetStudents()).Value;
            ViewBag.Teachers = (await _teacherService.GetOpenTeachers()).Value;
            ViewBag.Grades = (await _gradeService.GetOpenGrades()).Value;
            ViewBag.GradeGroups = Enum.GetNames<GradeGroup>();
            ViewBag.Years = Enumerable.Range(year - yearsRange, (year + yearsRange + 2) - year);
            return View();
        }

        [Route("[controller]/[action]/{oid:guid}")]
        public async Task<IActionResult> Edit(Guid oid)
        {
            var result = await _enrollmentService.GetEnrollmentToUpdate(oid);
            if (result.Error.Code == "Students.NotFound")
                return NotFound(result.Error);

            var year = DateTime.Now.Year;
            var yearsRange = 10;
            ViewBag.Students = (await _studentService.GetStudents()).Value;
            ViewBag.Teachers = (await _teacherService.GetTeachers()).Value;
            ViewBag.Grades = (await _gradeService.GetGrades()).Value;
            ViewBag.GradeGroups = Enum.GetNames<GradeGroup>();
            ViewBag.Years = Enumerable.Range(year - yearsRange, (year + yearsRange + 2) - year);
            return View(result.Value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnrollmentCreationDto enrollmentCreationDto)
        {
            var result = await _enrollmentService.CreateEnrollment(enrollmentCreationDto);
            if(result.IsFailure)
                return result.Error.Code.Contains(".NotFound") ? NotFound(result.Error) : BadRequest(result.Error);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("[controller]/[action]/{oid:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid oid, EnrollmentToUpdateDto enrollmentUpdateDto)
        {
            var result = await _enrollmentService.UpdateEnrollment(oid, enrollmentUpdateDto);
            if (result.IsFailure)
                return result.Error.Code.Contains(".NotFound") ? NotFound(result.Error) : BadRequest(result.Error);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("[controller]/[action]/{oid:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid oid)
        {
            var result = await _enrollmentService.DeleteEnrollment(oid);
            if (result.Error.Code == "Enrollments.NotFound")
                return NotFound(result.Error);

            return RedirectToAction(nameof(Index));
        }
    }
}
