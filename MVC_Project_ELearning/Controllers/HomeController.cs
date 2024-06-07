using Microsoft.AspNetCore.Mvc;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels;
using MVC_Project_ELearning.ViewModels.Sliders;
using System.Diagnostics;

namespace MVC_Project_ELearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;

        public HomeController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public async Task<IActionResult> Index()
        {
           var slider = await _sliderService.GetAllAsync();

            HomeVM model = new()
            {
                Sliders = slider.Select(m => new SliderVM
                {
                    Image = m.Image,
                    Title = m.Title,
                    Description = m.Description,

                })
            };
            return View(model);
        }

       
    }
}
