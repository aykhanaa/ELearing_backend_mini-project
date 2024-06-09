using Microsoft.EntityFrameworkCore;
using MVC_Project_ELearning.Data;
using MVC_Project_ELearning.Helpers.Extensions;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.ViewModels.Information;
using MVC_Project_ELearning.ViewModels.Sliders;

namespace MVC_Project_ELearning.Services
{
    public class InformationService : IInformationService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public InformationService(AppDbContext context,
                                  IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task CreateAsync(InformationCreateVM request)
        {
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            string path = _env.GenerateFilePath("img", fileName);

            await request.Image.SaveFileToLocalAsync(path);

            await _context.Informations.AddAsync(new Information
            {
                Title = request.Title,
                Description = request.Description,
                Image = fileName
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var information = await _context.Informations.FirstOrDefaultAsync(m => m.Id == id);

            string imgPath = _env.GenerateFilePath("img", information.Image);
            imgPath.DeleteFileFromLocal();

            _context.Informations.Remove(information);

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(int id, InformationEditVM request)
        {
            var information = await _context.Informations.FirstOrDefaultAsync(m => m.Id == id);

            information.Title = request.Title;

            information.Description = request.Description;

            if (request.NewImage is not null)
            {
                string oldPath = _env.GenerateFilePath("img", information.Image);

                oldPath.DeleteFileFromLocal();

                string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

                string newPath = _env.GenerateFilePath("img", fileName);

                await request.NewImage.SaveFileToLocalAsync(newPath);

                information.Image = fileName;
            }

            await _context.SaveChangesAsync();
        }

        public async Task EditAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExceptByIdAsync(int id, string title)
        {
            return await _context.Informations.AnyAsync(m => m.Title.Trim() == title.Trim() && m.Id != id);
        }

        public async Task<bool> ExistAsync(string title, string description)
        {
            return await _context.Informations.AnyAsync(m => m.Title.Trim() == title.Trim() || m.Description.Trim() == description.Trim());
        }

        public async Task<bool> ExistExceptByIdAsync(int id, string title, string description)
        {
            return await _context.Informations.AnyAsync(m => m.Id != id && (m.Title.Trim() == title.Trim() || m.Description.Trim() == description.Trim()));
        }

        public async Task<IEnumerable<InformationVM>> GetAllAsync(int? take = null)
        {
            IEnumerable<Information> informations;
            if (take == null)
            {
                informations = await _context.Informations.ToListAsync();
            }
            else
            {
                informations = await _context.Informations.Take((int)take).ToListAsync();
            }

            return informations.Select(m => new InformationVM { Id = m.Id, Title = m.Title, Description = m.Description, Image = m.Image, CreatedDate = m.CreatedDate.ToString("MM.dd.yyyy") });
        }

        public async Task<InformationVM> GetByIdAsync(int id)
        {
            Information information = await _context.Informations.FirstOrDefaultAsync(m => m.Id == id);

            return new InformationVM
            {
                Id = information.Id,
                Title = information.Title,
                Description = information.Description,
                Image = information.Image,
                CreatedDate = information.CreatedDate.ToString("MM.dd.yyyy")
            };
        }

    }
}
