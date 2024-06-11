using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project_ELearning.Data;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Projekt_Elearning.Services.Interfaces;

namespace MVC_Projekt_Elearning.Services
{
    public class SocialService : ISosialService
    {
        private readonly AppDbContext _context;
        public SocialService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sosial>> GetAllAsync()
        {
            return await _context.Sosials.ToListAsync();
        }

        public async Task<SelectList> GetAllSelectedAsync()
        {
            var socials = await _context.Sosials.Where(m => !m.SoftDeleted).ToListAsync();
            return new SelectList(socials, "Id", "Name");
        }
        public async Task CreateAsync(Sosial social)
        {
            await _context.Sosials.AddAsync(social);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Sosial social)
        {
            _context.Sosials.Remove(social);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Sosials.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task<Sosial> GetByIdAsync(int id)
        {
            return await _context.Sosials.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
