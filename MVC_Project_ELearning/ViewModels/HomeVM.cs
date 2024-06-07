using MVC_Project_ELearning.ViewModels.Information;
using MVC_Project_ELearning.ViewModels.Sliders;

namespace MVC_Project_ELearning.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<SliderVM> Sliders { get; set; }
        public IEnumerable<InformationVM> Informations { get; set; }

    }
}
