namespace MVC_Project_ELearning.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public Instructor Instructor { get; set; }
        public int InstructorId { get; set; }
        public int Duration { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<CourseImage> CourseImages { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
    }
}
