using MVC_Project_ELearning.ViewModels.Sliders;

namespace MVC_Project_ELearning.Services.Interfaces
{
    public interface IInformationService
    {
        Task<IEnumerable<SliderVM>> GetAllAsync(int? take = null);
        Task CreateAsync(SliderCreateVM request);
        Task<bool> ExistAsync(string title, string description);
        Task DeleteAsync(int id);
        Task EditAsync(int id, SliderEditVM request);
        Task<SliderVM> GetByIdAsync(int id);
        Task<bool> ExistExceptByIdAsync(int id, string title, string description);
        Task<bool> ExceptByIdAsync(int id, string title);
        Task EditAsync();

    }
}
