using Microsoft.AspNetCore.Mvc;
using MVC_Project_ELearning.Helpers.Extensions;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels.Categories;
using MVC_Project_ELearning.ViewModels.Course;

namespace MVC_Project_ELearning.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
}    };