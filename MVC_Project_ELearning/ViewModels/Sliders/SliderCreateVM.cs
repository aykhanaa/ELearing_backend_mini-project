using System.ComponentModel.DataAnnotations;

namespace MVC_Project_ELearning.ViewModels.Sliders
{
    public class SliderCreateVM
    {
        [Required(ErrorMessage = "This input can't be empty")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "This input can't be empty")]
        public string Description { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
