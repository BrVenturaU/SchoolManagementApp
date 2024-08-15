using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Application.Teachers;
using SchoolManagementApp.Shared.Dtos.Teachers;
using SchoolManagementApp.Shared.Enums;

namespace SchoolManagementApp.Web.Controllers
{
    public class TeachersController(ITeacherService teacherService) : Controller
    {
        private readonly ITeacherService _teacherService = teacherService;

        public async Task<IActionResult> Index()
        {
            var result = await _teacherService.GetTeachers();
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
            var result = await _teacherService.GetTeacherToUpdate(oid);
            if (result.Error.Code == "Students.NotFound")
                return NotFound(result.Error);

            ViewBag.Genders = Enum.GetNames<Gender>();
            ViewBag.Oid = oid;
            return View(result.Value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherCreationDto teacherCreationDto)
        {
            var result = await _teacherService.CreateTeacher(teacherCreationDto);
            if(result.IsFailure)
                return View(teacherCreationDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("[controller]/[action]/{oid:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid oid, TeacherToUpdateDto teacherUpdateDto)
        {
            var result = await _teacherService.UpdateTeacher(oid, teacherUpdateDto);
            if (result.Error.Code == "Teachers.NotFound")
                return NotFound(result.Error);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("[controller]/[action]/{oid:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid oid)
        {
            var result = await _teacherService.DeleteTeacher(oid);
            if (result.Error.Code == "Teachers.NotFound")
                return NotFound(result.Error);

            return RedirectToAction(nameof(Index));
        }
    }
}
