using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.ViewModels.About;
using MVC_Project_ELearning.ViewModels.Information;
using MVC_Project_ELearning.ViewModels.Sliders;
using MVC_Projekt_Elearning.ViewModels.Categories;

namespace MVC_Project_ELearning.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<SliderVM> Sliders { get; set; }
        public IEnumerable<InformationVM> Informations { get; set; }
        public MVC_Project_ELearning.Models.About Abouts{ get; set; }
        public CategoryCourseVM CategoryLast { get; set; }
        public CategoryCourseVM CategoryFirst { get; set; }
        public IEnumerable<CategoryCourseVM> Categories { get; set; }


    }
}

