using Microsoft.AspNetCore.Mvc;

namespace StudentAdmin.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ViewResult CreateStudent()
        {
            return View();
        }
        [HttpGet]
        public ViewResult CreateStudnet(object Student)
        {
            return View();
        }
    }
}
