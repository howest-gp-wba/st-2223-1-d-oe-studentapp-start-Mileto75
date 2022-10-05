using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Students.Core;
using Wba.Oefening.Students.Web.ViewModels;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseRepository _courseRepository;
        private readonly StudentRepository _studentRepository;
        public CoursesController()
        {
            _courseRepository = new CourseRepository();
            _studentRepository = new StudentRepository();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Courses()
        {
            //get the data
            var courses = _courseRepository
                .Courses;
            //create the model
            var coursesCoursesViewModel 
                = new CoursesCoursesViewModel();
            //fill the model
            coursesCoursesViewModel.Courses
                = courses.Select(c => new BaseViewModel
                { 
                    Id = c?.Id ?? 0,
                    Value = c?.Name ?? "<NoCourse>",
                });
            ViewBag.PageTitle = "Our courses";
            //pass the model to the view
            return View(coursesCoursesViewModel);
        }

        public IActionResult CourseStudents(int courseId)
        {
            //get the students in the course using Id
            var students = _studentRepository.
                GetStudentsInCourseId(courseId);
            //create the model
            var coursesCourseStudentsViewModel =
                new CoursesCourseStudentsViewModel();
            //fill the model
            coursesCourseStudentsViewModel
                .Students = students.
                Select(s => new BaseViewModel
                {
                    Id = s?.Id ?? 0,
                    Value = $"{s?.FirstName} {s?.LastName}" ?? "<NoName>"
                });
            //pass to the view
            ViewBag.PageTitle = "Students in course";
            return View(coursesCourseStudentsViewModel);
        }
    }
}
