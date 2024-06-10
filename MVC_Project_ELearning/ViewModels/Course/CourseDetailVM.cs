using MVC_Project_ELearning.Models;

namespace MVC_Project_ELearning.ViewModels.Course
{
    public class CourseDetailVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Category { get; set; }
        public List<CourseImageVM> Images { get; set; }
    }
}
