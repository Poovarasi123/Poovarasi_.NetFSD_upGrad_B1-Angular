using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HandsOnMVC_Demo2.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            string[] cities = { "Pune", "Chennai", "Hyderabad", "Mumbai", "Kochin" };
            ViewData["cities"] = cities;
            return View();
        }

        public IActionResult GetEmployees()
        {
            // Creating a list of employee names
            List<string> employees = new List<string>()
            {
                "Rohan", "Karan", "Jason", "Monica"
            };

            // Passing the list using the dynamic ViewBag property
            ViewBag.Employees = employees;
            return View();
        }
    }
}