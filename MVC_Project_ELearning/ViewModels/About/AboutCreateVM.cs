using System.ComponentModel.DataAnnotations;

namespace MVC_Project_ELearning.ViewModels.About
{
    public class AboutCreateVM
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
