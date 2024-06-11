using Microsoft.AspNetCore.Mvc;

namespace MVC_Project_ELearning.Areas.Admin.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
