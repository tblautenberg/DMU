using Microsoft.AspNetCore.Mvc;
using StudentAdminSys.Models;
<<<<<<< HEAD
using System.Diagnostics.Eventing.Reader;
=======
>>>>>>> b8d6ad93f106d28c774d696e444a3f7f0d9c8791

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
<<<<<<< HEAD
                return View("Congrats", student);
=======
                return View("StudentCreated", student);
<<<<<<< HEAD
            }
            else
            {
=======
>>>>>>> b8d6ad93f106d28c774d696e444a3f7f0d9c8791
            } else {
>>>>>>> 9ac2a147b83b79f2a1085239c7d533692521bbd6
                return View();
            }
        }

        public ViewResult StudentList()
        {
            return View(Repository.Students);
        }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

        [HttpPost, ActionName("DeleteStudent")]
        public IActionResult DeleteStudent(Student student) {
            if (Repository.RemoveStudent(student)) {
                return View("Index", Repository.Students);
            } else {
                return View("Error");
            }
        }
>>>>>>> b8d6ad93f106d28c774d696e444a3f7f0d9c8791
>>>>>>> 9ac2a147b83b79f2a1085239c7d533692521bbd6
    }
}
