using Microsoft.AspNetCore.Mvc;
using StudentCourseManagementSystem.Entities;
using StudentCourseManagementSystem.Repositories;

namespace StudentCourseManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var students = _repo.GetAll();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _repo.Add(student);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = _repo.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _repo.Update(student);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = _repo.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _repo.Delete(student.Id);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var student = _repo.GetById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Details(Student student)
        {
            _repo.Delete(student.Id);
            return RedirectToAction("Index");
        }
    }
}