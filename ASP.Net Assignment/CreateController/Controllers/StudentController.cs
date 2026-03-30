using Microsoft.AspNetCore.Mvc;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        return Content("Welcome to Student Page");
    }

    public IActionResult Details()
    {
        return Content("Student Details Page");
    }

    public IActionResult GetStudent(int id)
    {
        return Content("Student ID is " + id);
    }
}