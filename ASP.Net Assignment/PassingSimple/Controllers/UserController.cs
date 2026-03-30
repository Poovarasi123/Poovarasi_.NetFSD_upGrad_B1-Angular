using Microsoft.AspNetCore.Mvc;

namespace PassingSimple.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    namespace MvcApp.Controllers
    {
        public class UserController : Controller
        {
            public IActionResult Details(string name, int age)
            {
                return Content($"Name: {name}, Age: {age}");
            }
        }
    }
}