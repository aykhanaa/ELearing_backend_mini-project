using System.ComponentModel.DataAnnotations;

namespace MVC_Project_ELearning.Models
{
    public class Slider:BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
