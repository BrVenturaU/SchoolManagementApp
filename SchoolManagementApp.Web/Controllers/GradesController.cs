using Microsoft.AspNetCore.Mvc;
using SchoolManagementApp.Application.Grades;
using SchoolManagementApp.Shared.Dtos.Grades;
using SchoolManagementApp.Shared.Enums;

namespace SchoolManagementApp.Web.Controllers
{
    public class GradesController(IGradeService gradeService) : Controller
    {
        private readonly IGradeService _gradeService = gradeService;

        public async Task<IActionResult> Index()
        {
            var result = await _gradeService.GetGrades();
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
            var result = await _gradeService.GetGradeToUpdate(oid);
            if (result.Error.Code == "Grades.NotFound")
                return NotFound(result.Error);

            ViewBag.Genders = Enum.GetNames<Gender>();
            ViewBag.Oid = oid;
            return View(result.Value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GradeCreationDto gradeCreationDto)
        {
            var result = await _gradeService.CreateGrade(gradeCreationDto);
            if(result.IsFailure)
                return View(gradeCreationDto);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("[controller]/[action]/{oid:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid oid, GradeToUpdateDto gradeUpdateDto)
        {
            var result = await _gradeService.UpdateGrade(oid, gradeUpdateDto);
            if (result.Error.Code == "Grades.NotFound")
                return NotFound(result.Error);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("[controller]/[action]/{oid:guid}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid oid)
        {
            var result = await _gradeService.DeleteGrade(oid);
            if (result.Error.Code == "Grades.NotFound")
                return NotFound(result.Error);

            return RedirectToAction(nameof(Index));
        }
    }
}
