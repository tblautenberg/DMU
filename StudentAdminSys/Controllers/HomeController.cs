using Microsoft.AspNetCore.Mvc;
using StudentAdminSys.Models;

namespace StudentAdminSys.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.Students);
        }

        // This method deletes the student using studentId
        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            Student student = Repository.Find(studentId);

            if (student != null && Repository.RemoveStudent(student))
            {
                return RedirectToAction("Index");  // Redirect to the Index view after deletion
            }
            else
            {
                return View("Error");
            }
        }

        public ViewResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public ViewResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                Repository.AddStudent(student);
                return View("StudentCreated", student);
            }
            else
            {
                return View();
            }
        }

        public ViewResult StudentList()
        {
            return View(Repository.Students);
        }
    }
}
