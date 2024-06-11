using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.ViewModels.Categories;
using MVC_Projekt_Elearning.ViewModels.Categories;

namespace MVC_Project_ELearning.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryVM>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> GetByIdWithCoursesAsync(int id);
        Task<SelectList> GetAllSelectedAsync();
        Task<int> GetCountAsync();
        Task<bool> ExistAsync(string name);
        Task CreateAsync(CategoryCreateVM request);
        Task EditAsync(Category category, CategoryEditVM request);
        Task DeleteAsync(Category category);
        Task<IEnumerable<CategoryCourseVM>> GetAlWithProductCountAsync();
    }
}
