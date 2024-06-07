using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels;
using MVC_Project_ELearning.ViewModels.Information;
using MVC_Project_ELearning.ViewModels.Sliders;
using System.Diagnostics;

namespace MVC_Project_ELearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IInformationService _informationService;

        public HomeController(ISliderService sliderService, IInformationService informationService)
        {
            _sliderService = sliderService;
            _informationService = informationService;
        }

        public async Task<IActionResult> Index()
        {
           var slider = await _sliderService.GetAllAsync();
           var ınformation = await _informationService.GetAllAsync();

            HomeVM model = new()
            {
                Sliders = slider.Select(m => new SliderVM
                {
                    Image = m.Image,
                    Title = m.Title,
                    Description = m.Description,

                }),
                Informations = ınformation.Select(m => new InformationVM
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
