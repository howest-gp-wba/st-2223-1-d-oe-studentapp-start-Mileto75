using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Students.Core;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentRepository _studentRepository;

        public StudentsController()
        {
            _studentRepository = new StudentRepository();
        }
        public IActionResult ShowAll()
        {
            var studentShowAllViewModel = new
                StudentsShowAllViewModel
            {
                Students = _studentRepository
                .Students
                .Select(s => new BaseViewModel 
                {
                    Id = s?.Id ?? 0,
                    Value = $"{s?.FirstName} {s?.LastName}" ?? "<NoName>"
                })
            };
            ViewBag.PageTitle = "Our students";
            return View(studentShowAllViewModel);
        }

        public IActionResult ShowStudentCourses(int id)
        {
            ViewBag.PageTitle = "Courses of student";
            return View();
        }
    }
}
