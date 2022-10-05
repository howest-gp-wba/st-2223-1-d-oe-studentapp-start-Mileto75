using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Students.Core;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class TeachersController : Controller
    {
        private readonly TeacherRepository _teacherRepository;

        public TeachersController()
        {
            _teacherRepository = new TeacherRepository();
        }
        public IActionResult ShowAll()
        {
            var teachersShowAllViewModel = new TeachersShowAllViewModel 
            {
                Teachers = _teacherRepository
                .Teachers
                .Select(t => new BaseViewModel 
                {
                    Id = t?.Id ?? 0,
                    Value = $"{t?.FirstName} {t?.LastName}" ?? "<NoName>"
                })
            };
            ViewBag.PageTitle = "Our teachers";
            return View(teachersShowAllViewModel);
        }

        public IActionResult Details()
        {
            ViewBag.PageTitle = "Teacher details";
            return View();
        }
    }
}
