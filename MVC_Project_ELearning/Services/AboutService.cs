using Microsoft.EntityFrameworkCore;
using MVC_Project_ELearning.Data;
using MVC_Project_ELearning.Helpers.Extensions;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels.About;
using MVC_Project_ELearning.ViewModels.Information;

namespace MVC_Project_ELearning.Services
{
    public class AboutService : IAboutService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AboutService(AppDbContext context,
                            IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task CreateAsync(AboutCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = _env.GenerateFilePath("img", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Abouts.AddAsync(new About
            {
                Title = request.Title,
                Description = request.Description,
                Image = fileName
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var about = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);

            string imgPath = _env.GenerateFilePath("img", about.Image);
            imgPath.DeleteFileFromLocal();

            _context.Abouts.Remove(about);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, AboutEditVM request)
        {
            var about = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);

            about.Title = request.Title;

            about.Description = request.Description;

            if (request.NewImage is not null)
            {
                string oldPath = _env.GenerateFilePath("img", about.Image);

                oldPath.DeleteFileFromLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

                string newPath = _env.GenerateFilePath("img", fileName);

                await request.NewImage.SaveFileToLocalAsync(newPath);

                about.Image = fileName;
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExceptByIdAsync(int id, string title)
        {
            return await _context.Abouts.AnyAsync(m => m.Title.Trim() == title.Trim() && m.Id != id);
        }

        public async Task<bool> ExistAsync(string title, string description)
        {
            return await _context.Abouts.AnyAsync(m => m.Title.Trim() == title.Trim() || m.Description.Trim() == description.Trim());
        }
    

        public async Task<bool> ExistExceptByIdAsync(int id, string title, string description)
        {
            return await _context.Abouts.AnyAsync(m => m.Id != id && (m.Title.Trim() == title.Trim() || m.Description.Trim() == description.Trim()));
        }

        public async Task<IEnumerable<AboutVM>> GetAllAsync(int? take = null)
        {
            IEnumerable<About> abouts;
            if (take == null)
            {
                abouts = await _context.Abouts.ToListAsync();
            }
            else
            {
                abouts = await _context.Abouts.Take((int)take).ToListAsync();
            }

            return abouts.Select(m => new AboutVM { Id = m.Id, Title = m.Title, Description = m.Description, Image = m.Image, CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy") });
        }

        public async Task<AboutVM> GetByIdAsync(int id)
        {
            About about = await _context.Abouts.FirstOrDefaultAsync(m => m.Id == id);

            return new AboutVM
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                Image = about.Image,
                CreatedDate = about.CreatedDate.ToString("MM.dd.yyyy")
            };
        }
        public async Task<About> GetByAboutAsync()
        {
            return await _context.Abouts.FirstOrDefaultAsync();
           
        }
    }
}
