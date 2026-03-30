using Microsoft.AspNetCore.Mvc;

namespace MultipleControllers.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    namespace MvcApp.Controllers
    {
        public class TeacherController : Controller
        {
            public IActionResult Index()
            {
                return Content("Teacher Index Page");
            }

            public IActionResult Details()
            {
                return Content("Teacher Details Page");
            }
        }
    }
}
