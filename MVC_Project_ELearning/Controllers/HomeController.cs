using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels;
using MVC_Project_ELearning.ViewModels.About;
using MVC_Project_ELearning.ViewModels.Information;
using MVC_Project_ELearning.ViewModels.Sliders;
using System.Diagnostics;

namespace MVC_Project_ELearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IInformationService _informationService;
        private readonly IAboutService _aboutService;

        public HomeController(ISliderService sliderService, 
                              IInformationService informationService,
                              IAboutService aboutService)
        {
            _sliderService = sliderService;
            _informationService = informationService;
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
           var slider = await _sliderService.GetAllAsync();
           var ınformation = await _informationService.GetAllAsync();
            //var about =  await _aboutService.GetAllAsync();
            var about = await _aboutService.GetByAboutAsync();

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
                    Id = m.Id,
                    Image = m.Image,
                    Title = m.Title,
                    Description = m.Description,
                    CreatedDate = m.CreatedDate

                }),
                Abouts =about



            };
            return View(model);
        }

       
    }
}
