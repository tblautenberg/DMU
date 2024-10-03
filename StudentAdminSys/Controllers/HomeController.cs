using Microsoft.AspNetCore.Mvc;
using StudentAdminSys.Models;

namespace StudentAdminSys.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View(Repository.Students);
        }

        public ViewResult CreateStudent() {
            return View();
        }

        [HttpPost]
        public ViewResult CreateStudent(Student student) {
            if (ModelState.IsValid) {
                Repository.AddStudent(student);
                return View("StudentCreated", student);
            } else {
                return View();
            }
        }

        public ViewResult StudentList() {
            return View(Repository.Students);
        }

        [HttpPost, ActionName("DeleteStudent")]
        public IActionResult DeleteStudent(Student student) {
            if (Repository.RemoveStudent(student)) {
                return View("Index", Repository.Students);
            } else {
                return View("Error");
            }
        }
    }
}