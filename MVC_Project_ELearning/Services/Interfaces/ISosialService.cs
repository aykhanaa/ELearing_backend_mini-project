using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project_ELearning.Models;

namespace MVC_Project_ELearning.Services.Interfaces
{
    public interface ISosialService
    {
        Task<SelectList> GetAllSelectedAsync();
        Task<IEnumerable<Sosial>> GetAllAsync();
        Task<Sosial> GetByIdAsync(int id);
        Task<bool> ExistAsync(string name);
        Task CreateAsync(Sosial social);
        Task DeleteAsync(Sosial social);
        Task EditAsync();
    }
}
