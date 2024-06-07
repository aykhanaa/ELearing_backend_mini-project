using Microsoft.AspNetCore.Mvc;
using MVC_Project_ELearning.Data;
using MVC_Project_ELearning.Helpers.Extensions;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.Services;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels.Information;
using MVC_Project_ELearning.ViewModels.Sliders;

namespace MVC_Project_ELearning.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class InformationController : Controller
    {
        private readonly IInformationService _ınformationService;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public InformationController(IInformationService ınformationService,
                               AppDbContext context,
                               IWebHostEnvironment env)
        {
            _ınformationService = ınformationService;
            _context = context;

            _env = env;

        }
        public async Task< IActionResult> Index()
        {
            return View(await _ınformationService.GetAllAsync());
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InformationCreateVM request)
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

            bool existSlider = await _ınformationService.ExistAsync(request.Title, request.Description);

            //if (existSlider)
            //{
            //    ModelState.AddModelError("Title", "Information with this title or description already exists");
            //    ModelState.AddModelError("Description", "Information with this title or description already exists");
            //    return View();
            //}

            await _ınformationService.CreateAsync(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _ınformationService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            await _ınformationService.DeleteAsync(blog.Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _ınformationService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();

            return View(new InformationDetailVM
            {
                Title = blog.Title,
                Description = blog.Description,
                CreatedDate = blog.CreatedDate,
                Image = blog.Image
            });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var ınformation = await _context.Informations.FindAsync(id);
            if (ınformation == null)
            {
                return NotFound();
            }

            var viewModel = new InformationEditVM
            {
                Image = ınformation.Image,
                Title = ınformation.Title,
                Description = ınformation.Description

            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, InformationEditVM request)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var ınformation = await _context.Informations.FindAsync(id);
            if (ınformation == null)
            {
                return NotFound();
            }

            if (request.NewImage != null)
            {

                if (!request.NewImage.CheckFileType("image/"))
                {
                    ModelState.AddModelError("NewImage", "Accept only image format");
                    return View(request);
                }
                if (!request.NewImage.CheckFileSize(1024))
                {
                    ModelState.AddModelError("NewImage", "Image size must be max 1024 KB");
                    return View(request);
                }

                string oldPath = _env.GenerateFilePath("img/", ınformation.Image);
                oldPath.DeleteFileFromLocal();
                string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
                string newPath = _env.GenerateFilePath("img/", fileName);
                await request.NewImage.SaveFileToLocalAsync(newPath);
                ınformation.Image = fileName;
            }


            ınformation.Title = request.Title;
            ınformation.Description = request.Description;


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


    }
}
