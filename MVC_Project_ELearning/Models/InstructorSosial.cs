using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project_ELearning.Models
{
    public class InstructorSosial
    {
        public int Id { get; set; }
        public Instructor Instructor { get; set; }

        [ForeignKey(nameof(Instructor))]
        public int InstructorId { get; set; }
        public Sosial Sosial { get; set; }
        [ForeignKey(nameof(Sosial))]
        public int SosialId { get;set; }
        public string SosialLink { get; set; }

    }
}
