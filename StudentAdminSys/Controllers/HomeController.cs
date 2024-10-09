using Microsoft.AspNetCore.Mvc;
using StudentAdminSys.Models;
using System.Diagnostics.Eventing.Reader;

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
                return View("Congrats", student);
            } else {
                return View();
            }
        }

        public ViewResult StudentList() {
            return View(Repository.Students);
        }
    }
}