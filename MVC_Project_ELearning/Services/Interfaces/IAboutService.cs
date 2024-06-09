using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.ViewModels.About;
using MVC_Project_ELearning.ViewModels.Information;

namespace MVC_Project_ELearning.Services.Interfaces
{
    public interface IAboutService
    {
        Task<IEnumerable<AboutVM>> GetAllAsync(int? take = null);
        Task CreateAsync(AboutCreateVM request);
        Task<bool> ExistAsync(string title, string description);
        Task DeleteAsync(int id);
        Task EditAsync(int id, AboutEditVM request);
        Task<AboutVM> GetByIdAsync(int id);
        Task<bool> ExistExceptByIdAsync(int id, string title, string description);
        Task<bool> ExceptByIdAsync(int id, string title);
        Task EditAsync();
        Task<About> GetByAboutAsync();
    }
}
