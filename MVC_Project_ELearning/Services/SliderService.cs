using Microsoft.EntityFrameworkCore;
using MVC_Project_ELearning.Data;
using MVC_Project_ELearning.Helpers.Extensions;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels.Sliders;
using System.Reflection.Metadata;

namespace MVC_Project_ELearning.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderService(AppDbContext context,
                              IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task CreateAsync(SliderCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = _env.GenerateFilePath("img", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Sliders.AddAsync(new Slider
            {
                Title = request.Title,
                Description = request.Description,
                Image = fileName
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            string imgPath = _env.GenerateFilePath("img", slider.Image);
            imgPath.DeleteFileFromLocal();

            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();
        }


        public async Task<bool> ExistAsync(string title, string description)
        {
            return await _context.Sliders.AnyAsync(m => m.Title.Trim() == title.Trim() || m.Description.Trim() == description.Trim());
        }

        public async Task<IEnumerable<SliderVM>> GetAllAsync(int? take = null)
        {
            IEnumerable<Slider> sliders;
            if (take == null)
            {
                sliders = await _context.Sliders.ToListAsync();
            }
            else
            {
                sliders = await _context.Sliders.Take((int)take).ToListAsync();
            }

            return sliders.Select(m =>new SliderVM { Id = m.Id,Title =m.Title,Description =m.Description,Image = m.Image,CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy")});
        }

        public async Task<SliderVM> GetByIdAsync(int id)
        {
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            return new SliderVM
            {
                Id = slider.Id,
                Title = slider.Title,
                Description = slider.Description,
                Image = slider.Image,
                CreatedDate = slider.CreatedDate.ToString("MM.dd.yyyy")
            };
        }
    }
}
