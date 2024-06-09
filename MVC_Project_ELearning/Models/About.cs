using System.ComponentModel.DataAnnotations;

namespace MVC_Project_ELearning.Models
{
    public class About : BaseEntity
    {
        [Required]
        [StringLength(400)]
        public string Title { get; set; }
        [Required]
        [StringLength(800)]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
