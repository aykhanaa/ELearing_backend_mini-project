using System.ComponentModel.DataAnnotations;

namespace MVC_Project_ELearning.ViewModels.Information
{
    public class InformationEditVM
    {
        [Required(ErrorMessage = "This input can't be empty")]
        [StringLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "This input can't be empty")]
        public string Description { get; set; }
        public string Image { get; set; }
        public IFormFile NewImage { get; set; }
    }
}
