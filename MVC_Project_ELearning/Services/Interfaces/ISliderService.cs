using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.ViewModels.Sliders;

namespace MVC_Project_ELearning.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<SliderVM>> GetAllAsync(int? take = null);
        Task CreateAsync(SliderCreateVM request);
        Task<bool> ExistAsync(string title, string description);
        Task DeleteAsync(int id);
        Task<SliderVM> GetByIdAsync(int id);

    }
}
