using MVC_Project_ELearning.Models;
using MVC_Project_ELearning.ViewModels.About;
using MVC_Project_ELearning.ViewModels.Information;
using MVC_Project_ELearning.ViewModels.Sliders;

namespace MVC_Project_ELearning.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<SliderVM> Sliders { get; set; }
        public IEnumerable<InformationVM> Informations { get; set; }
        public MVC_Project_ELearning.Models.About Abouts{ get; set; }


    }
}

