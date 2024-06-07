using MVC_Project_ELearning.ViewModels.Information;
using MVC_Project_ELearning.ViewModels.Sliders;

namespace MVC_Project_ELearning.Services.Interfaces
{
    public interface IInformationService
    {
        Task<IEnumerable<InformationVM>> GetAllAsync(int? take = null);
        Task CreateAsync(InformationCreateVM request);
        Task<bool> ExistAsync(string title, string description);
        Task DeleteAsync(int id);
        Task EditAsync(int id, InformationEditVM request);
        Task<InformationVM> GetByIdAsync(int id);
        Task<bool> ExistExceptByIdAsync(int id, string title, string description);
        Task<bool> ExceptByIdAsync(int id, string title);
        Task EditAsync();

    }
}
