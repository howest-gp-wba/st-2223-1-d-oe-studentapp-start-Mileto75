using Microsoft.AspNetCore.Mvc;

namespace Wba.Oefening.Students.Web.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Students()
        {
            return View();
        }
    }
}
