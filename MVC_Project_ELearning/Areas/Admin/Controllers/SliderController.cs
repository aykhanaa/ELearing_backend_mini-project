using Microsoft.AspNetCore.Mvc;
using MVC_Project_ELearning.Helpers.Extensions;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels.Sliders;

namespace MVC_Project_ELearning.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IWebHostEnvironment _env;

        public SliderController(ISliderService sliderService,
                                 IWebHostEnvironment env)
        {
            _sliderService = sliderService;
            _env = env;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _sliderService.GetAllAsync());
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return View();
            }

            if (!request.Image.CheckFileSize(1024))
            {
                ModelState.AddModelError("Image", "Image size must be max 1024 KB");
                return View();
            }

            bool existSlider = await _sliderService.ExistAsync(request.Title, request.Description);

            if (existSlider)
            {
                ModelState.AddModelError("Title", "Slider with this title or description already exists");
                ModelState.AddModelError("Description", "Slider with this title or description already exists");
                return View();
            }

            await _sliderService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _sliderService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            await _sliderService.DeleteAsync(blog.Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _sliderService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            return View(new SliderDetailVM
            {
                Title = blog.Title,
                Description = blog.Description,
                CreatedDate = blog.CreatedDate,
                Image = blog.Image
            });
        }
    }
}
