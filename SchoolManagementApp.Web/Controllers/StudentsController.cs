using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.Application.Students;
using SchoolManagementApp.Domain.Students;
using SchoolManagementApp.Shared.Dtos.Students;
using SchoolManagementApp.Shared.Enums;

namespace SchoolManagementApp.Web.Controllers
{
    public class StudentsController(IStudentService studentService) : Controller
    {
        private readonly IStudentService _studentService = studentService;

        public async Task<IActionResult> Index()
        {
            var result = await _studentService.GetStudents();
            return View(result.Value);
        }

        public IActionResult Create()
        {
            ViewBag.Genders = Enum.GetNames<Gender>();
            return View();
        }

        [Route("[controller]/[action]/{oid:guid}")]
        public async Task<IActionResult> Edit(Guid oid)
        {
            var result = await _studentService.GetStudentToUpdate(oid);
            if (result.Error.Code == "Students.NotFound")
                return NotFound(result.Error);

            ViewBag.Genders = Enum.GetNames<Gender>();
            ViewBag.Oid = oid;
            return View(result.Value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentCreationDto studentCreationDto)
        {
            var result = await _studentService.CreateStudent(studentCreationDto);
            if(result.IsFailure)
                return View(studentCreationDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("[controller]/[action]/{oid:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid oid, StudentToUpdateDto studentUpdateDto)
        {
            var result = await _studentService.UpdateStudent(oid, studentUpdateDto);
            if (result.Error.Code == "Students.NotFound")
                return NotFound(result.Error);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("[controller]/[action]/{oid:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid oid)
        {
            var result = await _studentService.DeleteStudent(oid);
            if (result.Error.Code == "Students.NotFound")
                return NotFound(result.Error);

            return RedirectToAction(nameof(Index));
        }
    }
}
