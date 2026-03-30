using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var student = new Student
            {
                Id = 1,
                Name = "John",
                Age = 22,
                Email = "john@gmail.com"
            };

            return View(student);
        }
    }
}